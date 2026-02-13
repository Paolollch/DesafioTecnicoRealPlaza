using System.Globalization;

namespace Caso2;

public class MoneyParts
{
    private static readonly int[] DenominationsCents = new int[]
    {
        5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000
    };

    public List<List<decimal>> Build(string amountStr)
    {
        if (string.IsNullOrWhiteSpace(amountStr)) return null;
        amountStr = amountStr.Trim().Replace(',', '.');
        if (!decimal.TryParse(amountStr, NumberStyles.Number, CultureInfo.InvariantCulture, out var amountDecimal))
            return null;

        if (amountDecimal < 0) return null;

        var target = (int)Math.Round(amountDecimal * 100m);
        if (target % 5 != 0) return null;

        var results = new List<List<decimal>>();
        var current = new List<int>();

        void Recurse(int startIndex, int remaining)
        {
            if (remaining == 0)
            {
                var combo = current.Select(c => c / 100m).ToList();
                results.Add(combo);
                return;
            }

            for (int i = startIndex; i < DenominationsCents.Length; i++)
            {
                var coin = DenominationsCents[i];
                if (coin > remaining) continue;
                current.Add(coin);
                Recurse(i, remaining - coin);
                current.RemoveAt(current.Count - 1);
            }
        }

        Recurse(0, target);
        return results;
    }
}

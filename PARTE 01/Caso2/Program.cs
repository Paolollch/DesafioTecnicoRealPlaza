using Caso2;
using System.Globalization;

var moneyParts = new MoneyParts();

Console.WriteLine("Caso 2 - MoneyParts\n");
while (true)
{
	Console.Write("Ingrese monto (ej: 0.1 o 10.50) o 'salir': ");
	var line = Console.ReadLine()?.Trim();
	if (string.Equals(line, "salir", StringComparison.OrdinalIgnoreCase)) break;
	var combos = moneyParts.Build(line ?? string.Empty);
	if (combos == null)
	{
		Console.WriteLine("Monto inválido o no representable con denominaciones de 0.05.");
		continue;
	}

	Console.WriteLine($"Se encontraron {combos.Count} combinaciones. Mostrando hasta 100:");
	for (int i = 0; i < Math.Min(combos.Count, 100); i++)
	{
		Console.WriteLine($"[{string.Join(", ", combos[i].Select(d => d.ToString("0.##", CultureInfo.InvariantCulture)))}]");
	}
	Console.WriteLine();
}

Console.WriteLine("Presione Enter para salir...");
Console.ReadLine();

using Caso1;
using System;

var orderRange = new OrderRange();

Console.WriteLine("Caso 1 - OrderRange\n");
while (true)
{
    Console.Write("Ingrese números enteros positivos separados por comas (ej: 2,1,4,5) o 'salir': ");
    var line = Console.ReadLine()?.Trim();
    if (string.Equals(line, "salir", StringComparison.OrdinalIgnoreCase)) break;

    var parts = (line ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    var nums = new List<int>();
    foreach (var p in parts)
    {
        if (int.TryParse(p, out var n) && n > 0) nums.Add(n);
    }

    if (nums.Count == 0)
    {
        Console.WriteLine("No se ingresaron números válidos.");
    }
    else
    {
        var resultado = orderRange.Build(nums);
        Console.WriteLine($"Entrada: [{string.Join(", ", nums)}]");
        Console.WriteLine($"Pares:   [{string.Join(", ", resultado.Pares)}]");
        Console.WriteLine($"Impares: [{string.Join(", ", resultado.Impares)}]");
    }

    Console.WriteLine();
}

Console.WriteLine("Presione Enter para salir...");
Console.ReadLine();


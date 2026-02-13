using Caso1;

static void MainLoop()
{
    var orderRange = new OrderRange();

    while (true)
    {
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1) Caso 1 - OrderRange (pares e impares)");
        Console.WriteLine("2) Salir");
        Console.Write("Opción: ");
        var opt = Console.ReadLine()?.Trim();

        if (opt == "2" || string.Equals(opt, "salir", StringComparison.OrdinalIgnoreCase)) break;

        if (opt == "1")
        {
            Console.Write("Ingrese números enteros positivos separados por comas (ej: 2,1,4,5): ");
            var line = Console.ReadLine() ?? string.Empty;
            var parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
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
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }
}

MainLoop();

Console.WriteLine("Presione Enter para salir...");
Console.ReadLine();


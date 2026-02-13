namespace Caso1;

/// <summary>
/// Clase que separa una colección de enteros positivos en pares e impares, ambos ordenados ascendentemente.
/// </summary>
public class OrderRange
{
    /// <summary>
    /// Recibe una colección de números enteros positivos y retorna dos listas ordenadas:
    /// una de números pares y otra de números impares.
    /// </summary>
    public (List<int> Pares, List<int> Impares) Build(IEnumerable<int> numbers)
    {
        var pares = numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToList();
        var impares = numbers.Where(n => n % 2 != 0).OrderBy(n => n).ToList();

        return (pares, impares);
    }
}

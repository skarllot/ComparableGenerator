namespace ConsoleApp;

internal static partial class Program
{
    public static void Main(string[] args)
    {
        var circle1 = new Circle { Radius = 1f };
        var circle2 = new Circle { Radius = 1f };
        Console.WriteLine(circle1.CompareTo(circle2));
    }
}
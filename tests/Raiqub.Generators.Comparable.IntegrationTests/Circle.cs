namespace Raiqub.Generators.Comparable.IntegrationTests;

[Comparable]
public partial class Circle
{
    public float Radius { get; init; }

    public int CompareTo(Circle? other)
    {
        if (other is null) return 1;
        return Radius.CompareTo(other.Radius);
    }
}
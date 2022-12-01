namespace Raiqub.Generators.Comparable.IntegrationTests;

[Comparable]
public partial record CircleData(float Radius)
{
    public int CompareTo(CircleData? other)
    {
        if (other is null) return 1;
        return Radius.CompareTo(other.Radius);
    }

    public override int GetHashCode()
    {
        return Radius.GetHashCode();
    }
}
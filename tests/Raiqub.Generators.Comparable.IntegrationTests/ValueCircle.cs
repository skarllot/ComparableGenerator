namespace Raiqub.Generators.Comparable.IntegrationTests;

[Comparable]
public readonly partial struct ValueCircle
{
    public readonly float Radius;

    public ValueCircle(float radius) => Radius = radius;

    public int CompareTo(ValueCircle other) => Radius.CompareTo(other.Radius);

    public override int GetHashCode() => Radius.GetHashCode();
}
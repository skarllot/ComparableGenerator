namespace Raiqub.Generators.Comparable.Tests;

[UsesVerify]
public class ComparableGeneratorSnapshotTests
{
    [Fact]
    public Task GeneratesMembersForPartialClass()
    {
        const string source = @"using Raiqub.Generators.Comparable;

namespace TestNamespace;

[Comparable]
public partial class Circle
{
    public float Radius { get; init; }

    public int CompareTo(Circle? other)
    {
        if (other is null) return 1;
        return Radius.CompareTo(other.Radius);
    }
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task DoesNotGenerateMembersWithoutAttribute()
    {
        const string source = @"namespace TestNamespace;

public partial class Circle
{
    public float Radius { get; init; }

    public int CompareTo(Circle? other)
    {
        if (other is null) return 1;
        return Radius.CompareTo(other.Radius);
    }
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task DoesNotGenerateMembersWithoutCompareToMethod()
    {
        const string source = @"using Raiqub.Generators.Comparable;

namespace TestNamespace;

[Comparable]
public partial class Circle
{
    public float Radius { get; init; }
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task DoesNotGenerateMembersWithoutCorrectCompareToMethod()
    {
        const string source = @"using Raiqub.Generators.Comparable;

namespace TestNamespace;

[Comparable]
public partial class Circle
{
    public float Radius { get; init; }

    public long CompareTo(Circle? other)
    {
        if (other is null) return 1;
        return Radius.CompareTo(other.Radius);
    }
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task DoesNotGenerateMembersWhenMissingUsing()
    {
        const string source = @"namespace TestNamespace;

[Comparable]
public partial class Circle
{
    public float Radius { get; init; }

    public int CompareTo(Circle? other)
    {
        if (other is null) return 1;
        return Radius.CompareTo(other.Radius);
    }
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task GeneratesMembersForTwoPartialClassOnSameFile()
    {
        const string source = @"using Raiqub.Generators.Comparable;

namespace TestNamespace;

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

[Comparable]
public partial class OtherCircle
{
    public float Radius { get; init; }

    public int CompareTo(OtherCircle? other)
    {
        if (other is null) return 1;
        return Radius.CompareTo(other.Radius);
    }
}";

        return TestHelper.Verify(source);
    }

    [Fact]
    public Task GeneratesMembersForOnePartialClassWhenTwoExistsOnSameFile()
    {
        const string source = @"using Raiqub.Generators.Comparable;

namespace TestNamespace;

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

public partial class OtherCircle
{
    public float Radius { get; init; }

    public int CompareTo(OtherCircle? other)
    {
        if (other is null) return 1;
        return Radius.CompareTo(other.Radius);
    }
}";

        return TestHelper.Verify(source);
    }
}
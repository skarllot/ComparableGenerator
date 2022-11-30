using FluentAssertions;
using Xunit;

namespace Raiqub.Generators.Comparable.IntegrationTests;

public class ComparableTests
{
    [Fact]
    public void Given2EqualCirclesThenComparisonReturnsExpectedResult()
    {
        var circle1 = new Circle { Radius = 1f };
        var circle2 = new Circle { Radius = 1f };

        circle1.CompareTo(circle2).Should().Be(0);
        (circle1 == circle2).Should().BeTrue();
        (circle1 != circle2).Should().BeFalse();
        (circle1 > circle2).Should().BeFalse();
        (circle1 < circle2).Should().BeFalse();
        (circle1 >= circle2).Should().BeTrue();
        (circle1 <= circle2).Should().BeTrue();
    }

    [Fact]
    public void Given1CircleSmallerThanOtherThenComparisonReturnsExpectedResult()
    {
        var circle1 = new Circle { Radius = 1f };
        var circle2 = new Circle { Radius = 2f };

        circle1.CompareTo(circle2).Should().Be(-1);
        (circle1 == circle2).Should().BeFalse();
        (circle1 != circle2).Should().BeTrue();
        (circle1 > circle2).Should().BeFalse();
        (circle1 < circle2).Should().BeTrue();
        (circle1 >= circle2).Should().BeFalse();
        (circle1 <= circle2).Should().BeTrue();
    }

    [Fact]
    public void Given1CircleBiggerThanOtherThenComparisonReturnsExpectedResult()
    {
        var circle1 = new Circle { Radius = 10f };
        var circle2 = new Circle { Radius = 5f };

        circle1.CompareTo(circle2).Should().Be(1);
        (circle1 == circle2).Should().BeFalse();
        (circle1 != circle2).Should().BeTrue();
        (circle1 > circle2).Should().BeTrue();
        (circle1 < circle2).Should().BeFalse();
        (circle1 >= circle2).Should().BeTrue();
        (circle1 <= circle2).Should().BeFalse();
    }

    [Fact]
    public void Given1NullCircleThenComparisonReturnsExpectedResult()
    {
        var circle1 = new Circle { Radius = 10f };
        Circle? circle2 = null;

        circle1.CompareTo(circle2).Should().Be(1);
        (circle1 == circle2).Should().BeFalse();
        (circle1 != circle2).Should().BeTrue();
        (circle1 > circle2).Should().BeTrue();
        (circle1 < circle2).Should().BeFalse();
        (circle1 >= circle2).Should().BeTrue();
        (circle1 <= circle2).Should().BeFalse();

        (circle2 == circle1).Should().BeFalse();
        (circle2 != circle1).Should().BeTrue();
        (circle2 > circle1).Should().BeFalse();
        (circle2 < circle1).Should().BeTrue();
        (circle2 >= circle1).Should().BeFalse();
        (circle2 <= circle1).Should().BeTrue();
    }
}
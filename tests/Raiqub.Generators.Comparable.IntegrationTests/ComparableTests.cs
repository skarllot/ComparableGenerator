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
}
using FluentAssertions;
using Xunit;

namespace Raiqub.Generators.Comparable.IntegrationTests;

public class ComparableTestsStruct
{
    [Fact]
    public void Given2EqualValueCirclesThenComparisonReturnsExpectedResult()
    {
        var circle1 = new ValueCircle(1f);
        var circle2 = new ValueCircle(1f);

        circle1.CompareTo(circle2).Should().Be(0);
        (circle1 == circle2).Should().BeTrue();
        (circle1 != circle2).Should().BeFalse();
        (circle1 > circle2).Should().BeFalse();
        (circle1 < circle2).Should().BeFalse();
        (circle1 >= circle2).Should().BeTrue();
        (circle1 <= circle2).Should().BeTrue();
    }

    [Fact]
    public void Given1ValueCircleSmallerThanOtherThenComparisonReturnsExpectedResult()
    {
        var circle1 = new ValueCircle(1f);
        var circle2 = new ValueCircle(2f);

        circle1.CompareTo(circle2).Should().Be(-1);
        (circle1 == circle2).Should().BeFalse();
        (circle1 != circle2).Should().BeTrue();
        (circle1 > circle2).Should().BeFalse();
        (circle1 < circle2).Should().BeTrue();
        (circle1 >= circle2).Should().BeFalse();
        (circle1 <= circle2).Should().BeTrue();
    }

    [Fact]
    public void Given1ValueCircleBiggerThanOtherThenComparisonReturnsExpectedResult()
    {
        var circle1 = new ValueCircle(10f);
        var circle2 = new ValueCircle(5f);

        circle1.CompareTo(circle2).Should().Be(1);
        (circle1 == circle2).Should().BeFalse();
        (circle1 != circle2).Should().BeTrue();
        (circle1 > circle2).Should().BeTrue();
        (circle1 < circle2).Should().BeFalse();
        (circle1 >= circle2).Should().BeTrue();
        (circle1 <= circle2).Should().BeFalse();
    }

    [Fact]
    public void Given1NullValueCircleThenComparisonReturnsExpectedResult()
    {
        var circle1 = new ValueCircle(10f);
        ValueCircle? circle2 = null;

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
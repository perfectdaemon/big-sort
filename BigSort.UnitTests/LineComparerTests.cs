using BigSort.Sorter;
using FluentAssertions;
using Xunit;

namespace BigSort.UnitTests;

public class LineComparerTests
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void Compare(Line x, Line y, int expectedResult)
    {
        // Arrange
        var comparer = new LineComparer();

        // Act
        var result = comparer.Compare(x, y);

        // Assert
        result.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[]
        {
            new Line
            {
                Number = 1,
                String = "Apple"
            },
            new Line
            {
                Number = 1,
                String = "Apple"
            },
            0
        };

        yield return new object[]
        {
            new Line
            {
                Number = 1,
                String = "Apple"
            },
            new Line
            {
                Number = 2,
                String = "Apple"
            },
            -1
        };

        yield return new object[]
        {
            new Line
            {
                Number = 2,
                String = "Apple"
            },
            new Line
            {
                Number = 1,
                String = "Banana"
            },
            -1
        };
    }
}
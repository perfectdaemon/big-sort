using System.Text;
using BigSort.Sorter;
using FluentAssertions;
using Xunit;

namespace BigSort.UnitTests;

public class StreamReaderExtensionsTests
{
    [Fact]
    public void ReadLines()
    {
        // Arrange
        const string text = @"
231. Apple
123. Banana with . dot
1. Candy";

        var expected = new Line[]
        {
            new(231, " Apple"),
            new(123, " Banana with . dot"),
            new(1, " Candy")
        };
        using var stream = new MemoryStream(Encoding.Default.GetBytes(text));
        using var reader = new StreamReader(stream);

        // Act
        var lines = reader.ReadLines().ToArray();

        // Assert
        lines.Should().BeEquivalentTo(expected);
    }
}
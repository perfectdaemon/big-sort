using System.Text;

namespace BigSort.Sorter;

public static class StreamReaderExtensions
{
    public static IEnumerable<Line> ReadLines(this StreamReader reader)
    {
        int read;
        var sb = new StringBuilder();
        long lineNum = -1;
        while ((read = reader.Read()) > 0)
        {
            var c = (char)read;

            if (c == '.' && lineNum == -1)
            {
                lineNum = long.Parse(sb.ToString());
                sb.Clear();
            }
            else if (c is '\r' or '\n')
            {
                if (sb.Length > 0)
                {
                    yield return new(lineNum, sb.ToString());
                    lineNum = -1;
                    sb.Clear();
                }
            }
            else
                sb.Append(c);
        }

        if (lineNum != -1)
            yield return new(lineNum, sb.ToString());
    }
}
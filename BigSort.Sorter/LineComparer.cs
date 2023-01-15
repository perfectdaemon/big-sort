namespace BigSort.Sorter;

public sealed class LineComparer : IComparer<Line>
{
    private static readonly Lazy<LineComparer> s_lineComparer = new(() => new());

    public static readonly LineComparer Instance = s_lineComparer.Value;

    public int Compare(Line x, Line y)
    {
        var strComparison = string.Compare(x.String, y.String, StringComparison.Ordinal);
        return strComparison != 0
            ? strComparison
            : x.Number.CompareTo(y.Number);
    }
}
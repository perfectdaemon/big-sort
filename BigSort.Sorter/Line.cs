using System.Runtime.CompilerServices;

namespace BigSort.Sorter;

public readonly record struct Line(long Number, string String)
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTo(StreamWriter writer)
    {
        writer.Write(Number);
        writer.Write('.');
        writer.WriteLine(String);
    }
}
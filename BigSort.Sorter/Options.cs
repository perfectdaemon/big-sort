using CommandLine;

namespace BigSort.Sorter;

public sealed record Options
{
    [Option('i', "input", Required = false, Default = "input.txt", HelpText = "Input file name")]
    public string InputFileName { get; init; } = string.Empty;

    [Option('o', "output", Required = false, Default = "sorted.txt", HelpText = "Output sorted file name")]
    public string OutputFileName { get; init; } = string.Empty;

    [Option('c', "chunk", Required = false, Default = 3 * 1024 * 1024, HelpText = "Chunk size in lines of data")]
    public int ChunkSize { get; init; }

    [Option('t', "tempDir", Required = false, Default = "tmp/", HelpText = "Directory for temp chunk files")]
    public string TemporaryDirectory { get; init; } = string.Empty;
}
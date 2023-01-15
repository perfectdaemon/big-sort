using CommandLine;

public sealed record Options
{
    [Option('s', "size", Required = false, Default = 1024 * 1024 * 1024, HelpText = "Output file size in bytes")]
    public long FileSize { get; init; }

    [Option('o', "output", Required = false, Default = "output.txt", HelpText = "Output file name")]
    public string OutputFileName { get; init; } = string.Empty;

    [Option('m', "minNumber", Required = false, Default = 1, HelpText = "Minimal possible number")]
    public long MinNumber { get; init; }
    
    [Option('M', "maxNumber", Required = false, Default = 100000, HelpText = "Maximum possible number")]
    public long MaxNumber { get; init; }
    
    [Option('w', "maxWords", Required = false, Default = 4, HelpText = "Maximum possible word count")]
    public int MaxWords { get; init; }
}
using System.Text;
using BigSort.Generator;
using CommandLine;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(options =>
    {
        CheckArgsOrThrow(options);
        Generate(options);
    });

void CheckArgsOrThrow(Options options)
{
    if (options.FileSize <= 0)
        throw new ArgumentException("FileSize must be positive nonzero number", nameof(options.FileSize));

    if (options.MaxWords <= 0)
        throw new ArgumentException("MaxWords must be positive nonzero number", nameof(options.MaxWords));

    if (string.IsNullOrWhiteSpace(options.OutputFileName))
        throw new ArgumentException("OutputFileName must not be empty", nameof(options.OutputFileName));
}

void Generate(Options options)
{
    var random = new Random();
    var stringBuilder = new StringBuilder();
    using var file = File.CreateText(options.OutputFileName);
    while (file.BaseStream.Length < options.FileSize)
    {
        stringBuilder
            .Append(random.NextInt64(options.MinNumber, options.MaxNumber))
            .Append(". ");

        var wordsCount = random.NextInt64(1, options.MaxWords);
        for (int i = 0; i < wordsCount; ++i)
        {
            stringBuilder.Append(Words.GetRandom());
            if (i < wordsCount - 1)
                stringBuilder.Append(' ');
        }

        file.WriteLine(stringBuilder);
        stringBuilder.Clear();
    }
}
using System.Diagnostics;
using BigSort.Sorter;
using CommandLine;

ThreadPool.SetMinThreads(Environment.ProcessorCount, Environment.ProcessorCount);

var sw = Stopwatch.StartNew();
await Parser.Default
    .ParseArguments<Options>(args)
    .WithParsedAsync(options =>
    {
        CheckArgsOrThrow(options);
        return Sort(options);
    });

Console.WriteLine($"Total time: {sw.Elapsed}");

// The algorithm is simple:
// * Read N lines into a chunk
// * Sort chunk via Task.Run and write sorted result to a temporary file (without awaiting the task immediately)
// * Repeat it to the end of the input file
// * Await all of the sort tasks
// * Make and external merge sort:
// * * Open all temp files
// * * Read one line from all
// * * Find minimal line and write it to output file
// * * Read one line instead of written one
// * * Repeat until the end of all temp files 
async Task Sort(Options options)
{
    if (!Directory.Exists(options.TemporaryDirectory))
        Directory.CreateDirectory(options.TemporaryDirectory);

    var chunkFileNames = new List<string>();
    var chunk = new List<Line>(options.ChunkSize);
    var chunkSortTasks = new List<Task>();
    int currentChunkId = 0;

    // Read file line by line sequentially.
    // When line count becomes equal to options.ChunkSize sort the lines in-memory and write into temp file
    // The sort tasks fired without await 
    using (var reader = File.OpenText(options.InputFileName))
    {
        foreach (var line in reader.ReadLines())
        {
            chunk.Add(line);

            if (chunk.Count == options.ChunkSize)
            {
                var fileName = $"{options.TemporaryDirectory}{currentChunkId}.txt";
                var localChunk = chunk;

                chunkSortTasks.Add(Task.Run(() => SortChunk(localChunk, fileName)));
                chunkFileNames.Add(fileName);

                chunk = new(options.ChunkSize);
                ++currentChunkId;
            }
        }
    }

    // Sort last chunk
    if (chunk.Count > 0)
    {
        var fileName = $"{options.TemporaryDirectory}{currentChunkId}.txt";
        chunkSortTasks.Add(Task.Run(() => SortChunk(chunk, fileName)));
        chunkFileNames.Add(fileName);
    }

    await Task.WhenAll(chunkSortTasks);

    // Merge
    await using (var output = File.CreateText(options.OutputFileName))
    using (var mergeSorter = new MergeSorter(chunkFileNames))
    {
        mergeSorter.Do(output);
    }

    // Clean temp dir
    foreach (var fileName in chunkFileNames)
        File.Delete(fileName);
}

void SortChunk(List<Line> chunk, string fileName)
{
    chunk.Sort(LineComparer.Instance);
    using var file = File.CreateText(fileName);
    for (int i = 0; i < chunk.Count; ++i)
        chunk[i].WriteTo(file);
}

void CheckArgsOrThrow(Options options)
{
    if (string.IsNullOrWhiteSpace(options.InputFileName))
        throw new ArgumentException("OutputFileName must not be empty", nameof(options.InputFileName));

    if (!File.Exists(options.InputFileName))
        throw new ArgumentException($"File {options.InputFileName} does not exists", nameof(options.InputFileName));

    if (options.ChunkSize <= 0)
        throw new ArgumentException("ChunkSize must be positive nonzero number", nameof(options.ChunkSize));

    if (Directory.Exists(options.TemporaryDirectory) && Directory.EnumerateFiles(options.TemporaryDirectory).Any())
        throw new ArgumentException(
            $"Temporary directory {options.TemporaryDirectory} contains files. Clear it or use another temporary directory",
            nameof(options.TemporaryDirectory));

    if (string.IsNullOrWhiteSpace(options.OutputFileName))
        throw new ArgumentException("OutputFileName must not be empty", nameof(options.OutputFileName));
}
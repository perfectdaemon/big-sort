namespace BigSort.Sorter;

public sealed class MergeSorter : IDisposable
{
    private readonly List<StreamReader> _readers = new();
    private readonly List<IEnumerator<Line>> _lines = new();
    private readonly List<bool> _enumeratorFinished = new();
    private int _remain;

    public MergeSorter(IReadOnlyCollection<string> fileNames)
    {
        _remain = fileNames.Count;

        foreach (var fileName in fileNames)
        {
            var reader = File.OpenText(fileName);
            var enumerator = reader.ReadLines().GetEnumerator(); // TODO: write own enumerator to prevent boxing? 

            _readers.Add(reader);
            _lines.Add(enumerator);
            _enumeratorFinished.Add(false);

            enumerator.MoveNext();
        }
    }

    public void Do(StreamWriter output)
    {
        while (_remain > 0)
        {
            int minIndex = -1;
            for (int i = 0; i < _lines.Count; ++i)
            {
                if (_enumeratorFinished[i])
                    continue;

                if (minIndex == -1 || LineComparer.Instance.Compare(_lines[i].Current, _lines[minIndex].Current) < 0)
                    minIndex = i;
            }

            _lines[minIndex].Current.WriteTo(output);

            if (!_lines[minIndex].MoveNext())
            {
                _enumeratorFinished[minIndex] = true;
                --_remain;
            }
        }
    }

    public void Dispose()
    {
        foreach (var enumerator in _lines)
            enumerator.Dispose();

        foreach (var reader in _readers)
            reader.Dispose();
    }
}
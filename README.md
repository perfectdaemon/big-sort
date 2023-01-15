# BigSort

### Summary
This is the solution for generating and sorting big files using chunk sort along with external merge sort.

### Usage
* All apps must be built with `Release` configuration — using IDE or `dotnet build -c Release` command.
* Run `BigSort.Generator` for generate file. Use `--help` to see the supported options. Default values are provided for generate 1GiB file
* Run `BigSort.Sorter` for sort file. Use `--help` to see the supported options. Be sure to use `-i` or `--input` to provide path to the input file.
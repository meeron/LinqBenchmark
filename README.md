# LinqBenchmark
Simple benchmark to check linq performance

## Run benchmark
Clone repository then:
```bash
cd LinqBenchmark/
dotnet run -c Release
```

## Example results
```
BenchmarkDotNet v0.14.0, macOS Sequoia 15.1.1 (24B91) [Darwin 24.1.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

| Method         | Mean     | Error     | StdDev    | Gen0      | Gen1      | Gen2     | Allocated |
|--------------- |---------:|----------:|----------:|----------:|----------:|---------:|----------:|
| NestedForeach  | 3.030 ms | 0.0176 ms | 0.0156 ms | 1593.7500 | 1593.7500 | 597.6563 |   5.05 MB |
| LinqSelectMany | 2.754 ms | 0.0110 ms | 0.0086 ms |  597.6563 |  531.2500 | 199.2188 |   3.21 MB |


BenchmarkDotNet v0.14.0, macOS Sequoia 15.1.1 (24B91) [Darwin 24.1.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD


| Method         | Mean     | Error     | StdDev    | Gen0     | Gen1     | Gen2     | Allocated |
|--------------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|
| NestedForeach  | 3.615 ms | 0.0510 ms | 0.0477 ms | 800.7813 | 656.2500 | 507.8125 |   5.05 MB |
| LinqSelectMany | 2.155 ms | 0.0084 ms | 0.0066 ms | 375.0000 | 250.0000 | 246.0938 |   3.18 MB |

```

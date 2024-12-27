// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<LinqBenchmark>();

public class User
{
    public int Id { get; set; }
    public int[] ExternalIds { get; set; } = [];
}

public class ExternalUser
{
    public int UserId { get; set; }
    public int ExternalId { get; set; }
}

[MemoryDiagnoser]
public class LinqBenchmark
{
    private readonly User[] _data;

    public LinqBenchmark()
    {
        _data = Enumerable.Range(0, 1000).Select(i => new User
        {
            Id = i,
            ExternalIds = Enumerable.Range(0, 100).Select(id => id).ToArray(),
        }).ToArray();
    }
    
    [Benchmark]
    public ExternalUser[] NestedForeach()
    {
        var all = new List<ExternalUser>();
        foreach (var user in _data)
        {
            foreach (var externalId in user.ExternalIds)
            {
                all.Add(new ExternalUser
                {
                    UserId = user.Id,
                    ExternalId = externalId,
                });
            }
        }

        return all.ToArray();
    }

    [Benchmark]
    public ExternalUser[] LinqSelectMany()
    {
        return _data.SelectMany(user => user.ExternalIds.Select(id => new ExternalUser
        {
            UserId = user.Id,
            ExternalId = id,
        })).ToArray();
    }
}

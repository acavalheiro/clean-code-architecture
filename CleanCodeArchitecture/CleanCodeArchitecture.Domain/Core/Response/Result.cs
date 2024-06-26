namespace CleanCodeArchitecture.Domain.Core.Response;

public class Result
{
    public bool Success => !this.Errors.Any();

    public IEnumerable<string> Errors { get; set; } = new List<string>();

   
}

public class Result<T> : Result
{
    public T Data { get; set; }
}
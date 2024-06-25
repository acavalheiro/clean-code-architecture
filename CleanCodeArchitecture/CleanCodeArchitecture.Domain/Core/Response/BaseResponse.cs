namespace CleanCodeArchitecture.Domain.Core.Response;

public class BaseResponse
{
    public bool Success { get; set; }
    
    public IEnumerable<string> Errors { get; set; }

    public void SetErrors(IEnumerable<string> errors)
    {
        Success = false;
        Errors = errors;
    }
}

public class BaseResponse<T> : BaseResponse
{
    public T Data { get; set; }
}
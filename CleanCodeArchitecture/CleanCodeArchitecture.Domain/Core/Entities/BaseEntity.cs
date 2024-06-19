namespace CleanCodeArchitecture.Domain.Core.Entities;

public class BaseEntity
{
    
}

public interface IBaseEntity<T> where T : struct
{
    public T Id { get; set; }
}

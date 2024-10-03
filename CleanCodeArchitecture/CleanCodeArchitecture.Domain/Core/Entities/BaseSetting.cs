namespace CleanCodeArchitecture.Domain.Core.Entities;

public class BaseSetting<T> : IBaseEntity<int> where T : BaseEntity
{
    public int Id { get; set; }
}
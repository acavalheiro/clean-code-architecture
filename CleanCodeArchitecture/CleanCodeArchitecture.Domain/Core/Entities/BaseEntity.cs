namespace CleanCodeArchitecture.Domain.Core.Entities;

public class BaseEntity : IAuditableEntity, ISoftDeleteEntity
{
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
}

public interface IBaseEntity<T> where T : struct
{
    public T Id { get; set; }
}

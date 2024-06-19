namespace CleanCodeArchitecture.Domain.Core.Entities;

public interface ISoftDeleteEntity
{
    public bool IsDeleted { get; set; }
}
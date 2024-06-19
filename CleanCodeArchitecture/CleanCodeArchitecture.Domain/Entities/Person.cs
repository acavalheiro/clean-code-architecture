using System.ComponentModel.DataAnnotations;
using CleanCodeArchitecture.Domain.Core.Entities;
using CleanCodeArchitecture.Domain.Enums;

namespace CleanCodeArchitecture.Domain.Entities;

public class Person : BaseEntity, IBaseEntity<Guid>, IAuditableEntity, ISoftDeleteEntity
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public UserStatus Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
    
}
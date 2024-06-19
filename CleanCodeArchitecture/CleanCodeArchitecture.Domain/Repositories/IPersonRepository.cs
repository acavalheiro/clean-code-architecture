using CleanCodeArchitecture.Domain.Core.Repositories;
using CleanCodeArchitecture.Domain.Entities;

namespace CleanCodeArchitecture.Domain.Repositories;

public interface IPersonRepository : IBaseRepositoryAsync<Person>
{
    
}
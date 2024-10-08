using CleanCodeArchitecture.Domain.Core.Repositories;
using CleanCodeArchitecture.Domain.Entities;

namespace CleanCodeArchitecture.Domain.Repositories;

public interface ICompanyRepository : IBaseRepositoryAsync<Company>
{
    Task<Company> GetById(int id);

    Task<Company> GetByIdWithSettings(int id);
}
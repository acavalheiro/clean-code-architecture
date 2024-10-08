using CleanCodeArchitecture.Domain.Entities;
using CleanCodeArchitecture.Domain.Repositories;
using CleanCodeArchitecture.Infrastructure.Sql.Data;
using CleanCodeArchitecture.Infrastructure.Sql.Repositories.Core;
using Microsoft.Extensions.Logging;

namespace CleanCodeArchitecture.Infrastructure.Sql.Repositories;

public class CompanyRepository : BaseRepositoryAsync<Company> , ICompanyRepository
{
    private readonly ILogger<CompanyRepository> _logger;
    
    public CompanyRepository(ApplicationContext dbContext, ILogger<CompanyRepository> logger) : base(dbContext, logger)
    {
        _logger = logger;
    }
}
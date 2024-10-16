using CleanCodeArchitecture.Domain.Entities;
using CleanCodeArchitecture.Domain.Repositories;
using CleanCodeArchitecture.Infrastructure.Sql.Data;
using CleanCodeArchitecture.Infrastructure.Sql.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanCodeArchitecture.Infrastructure.Sql.Repositories;

public class CompanyRepository : BaseRepositoryAsync<Company> , ICompanyRepository
{
    private readonly ILogger<CompanyRepository> _logger;
    
    public CompanyRepository(ApplicationContext dbContext, ILogger<CompanyRepository> logger) : base(dbContext, logger)
    {
        _logger = logger;
    }

    public async Task<Company> GetById(int id)
    {
        return await this.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Company> GetByIdWithSettings(int id)
    {
        return await this.DbSet.Include(x => x.MainSettings).ThenInclude(x => x.ModulePrimarySettings)
            .Include(x => x.MainSettings).ThenInclude(x => x.ModuleSecondarySettings)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
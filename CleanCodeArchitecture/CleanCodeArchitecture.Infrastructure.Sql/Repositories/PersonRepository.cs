using CleanCodeArchitecture.Domain.Entities;
using CleanCodeArchitecture.Domain.Repositories;
using CleanCodeArchitecture.Infrastructure.Sql.Data;
using CleanCodeArchitecture.Infrastructure.Sql.Repositories.Core;
using Microsoft.Extensions.Logging;

namespace CleanCodeArchitecture.Infrastructure.Sql.Repositories;

public class PersonRepository : BaseRepositoryAsync<Person> , IPersonRepository
{
    private readonly ILogger<PersonRepository> _logger;
    
    public PersonRepository(ApplicationContext dbContext, ILogger<PersonRepository> logger) : base(dbContext, logger)
    {
        _logger = logger;
    }
}
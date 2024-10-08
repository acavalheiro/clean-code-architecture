using CleanCodeArchitecture.Domain.Core.Queries;
using CleanCodeArchitecture.Domain.Core.Response;
using CleanCodeArchitecture.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CleanCodeArchitecture.Application.Queries.Company;


public record ListCompaniesQuery() : IQuery<Result<IEnumerable<Domain.Entities.Company>>>;

public class ListCompaniesQueryHandler : IQueryHandler<ListCompaniesQuery,Result<IEnumerable<Domain.Entities.Company>>>
{
    private readonly ILogger<ListCompaniesQueryHandler> _logger;

    private readonly ICompanyRepository _companyRepository;

    public ListCompaniesQueryHandler(ILogger<ListCompaniesQueryHandler> logger, ICompanyRepository companyRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
    }

    public async Task<Result<IEnumerable<Domain.Entities.Company>>> Handle(ListCompaniesQuery request, CancellationToken cancellationToken)
    {
        var result = this._companyRepository.ListAllAsync();

        return new Result<IEnumerable<Domain.Entities.Company>>(result);
    }
}
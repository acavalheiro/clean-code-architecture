using CleanCodeArchitecture.Domain.Core.Queries;
using CleanCodeArchitecture.Domain.Core.Response;
using CleanCodeArchitecture.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CleanCodeArchitecture.Application.Queries.Company;


public record GetCompanyQuery(int? Id, Guid? Guid) : IQuery<Result<Domain.Entities.Company>>;


public class GetCompanyQueryHandler : IQueryHandler<GetCompanyQuery, Result<Domain.Entities.Company>>
{
    private readonly ILogger<ListCompaniesQueryHandler> _logger;

    private readonly ICompanyRepository _companyRepository;

    public GetCompanyQueryHandler(ILogger<ListCompaniesQueryHandler> logger, ICompanyRepository companyRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
    }

    public async Task<Result<Domain.Entities.Company>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var result = await this._companyRepository.GetByIdWithSettings(request.Id.Value);

        return result;
    }
}
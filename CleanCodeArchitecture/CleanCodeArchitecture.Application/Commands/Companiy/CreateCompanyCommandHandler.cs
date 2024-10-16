using CleanCodeArchitecture.Application.Commands.Person;
using CleanCodeArchitecture.Domain.Core.Commands;
using CleanCodeArchitecture.Domain.Core.Repositories;
using CleanCodeArchitecture.Domain.Core.Response;
using CleanCodeArchitecture.Domain.Entities;
using CleanCodeArchitecture.Domain.Repositories;
using System.Transactions;

namespace CleanCodeArchitecture.Application.Commands.Companiy;

public record CreateCompanyCommand(string name) : ICommand<Result<Domain.Entities.Company>>;

public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, Domain.Entities.Company>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyRepository _companyRepository;

    public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
    }

    public async Task<Result<Company>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company company = new Company()
        {
            CreatedBy = Guid.Empty,
            CreatedOn = DateTimeOffset.UtcNow,
            Name = request.name,
            MainSettings = new MainSettings()
        };

        //using var transaction = this._unitOfWork.BeginTransaction();

        await this._companyRepository.AddAsync(company);

        await this._unitOfWork.SaveChangesAsync();

        //await _unitOfWork.CommitTransactionAsync();

        return company;
    }
}
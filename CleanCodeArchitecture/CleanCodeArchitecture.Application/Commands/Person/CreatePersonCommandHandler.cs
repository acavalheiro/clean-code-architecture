using System.Diagnostics;
using CleanCodeArchitecture.Domain.Core.Commands;
using CleanCodeArchitecture.Domain.Core.Response;
using CleanCodeArchitecture.Domain.Repositories;
using MediatR;

namespace CleanCodeArchitecture.Application.Commands.Person;

public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, BaseResponse<Domain.Entities.Person>>
{
    private readonly IPersonRepository _personRepository;

    public CreatePersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }



    public async Task<BaseResponse<Domain.Entities.Person>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {

        Domain.Entities.Person person = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth.Value
        };

        await _personRepository.AddAsync(person);
        //return new Domain.Entities.Person();
        return new ValidationResponse<Domain.Entities.Person>() { Data = person };
    }



}
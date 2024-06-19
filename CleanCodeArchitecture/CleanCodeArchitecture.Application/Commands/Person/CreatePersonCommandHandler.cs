using CleanCodeArchitecture.Domain.Core.Commands;
using CleanCodeArchitecture.Domain.Repositories;

namespace CleanCodeArchitecture.Application.Commands.Person;

public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, Domain.Entities.Person>
{
    private readonly IPersonRepository _personRepository;

    public CreatePersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Domain.Entities.Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Person person = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth
        };
        
        await _personRepository.AddAsync(person);

        return person;
    }
}
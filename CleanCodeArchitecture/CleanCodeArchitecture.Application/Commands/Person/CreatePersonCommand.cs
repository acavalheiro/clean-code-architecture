using CleanCodeArchitecture.Domain.Core.Commands;

namespace CleanCodeArchitecture.Application.Commands.Person;

public record CreatePersonCommand(string FirstName, string LastName, string Email, DateOnly DateOfBirth) : ICommand<Domain.Entities.Person>;
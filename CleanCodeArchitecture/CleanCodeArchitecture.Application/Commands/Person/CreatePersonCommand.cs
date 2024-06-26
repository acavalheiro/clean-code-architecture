using CleanCodeArchitecture.Domain.Core.Commands;
using CleanCodeArchitecture.Domain.Core.Response;
using MediatR;

namespace CleanCodeArchitecture.Application.Commands.Person;

public record CreatePersonCommand(string FirstName, string LastName, string Email, DateOnly? DateOfBirth) : ICommand<Result<Domain.Entities.Person>>;
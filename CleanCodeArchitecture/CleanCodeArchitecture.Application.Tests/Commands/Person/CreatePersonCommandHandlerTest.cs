using CleanCodeArchitecture.Application.Commands.Person;
using CleanCodeArchitecture.Application.Core.PipelineBehavior;
using CleanCodeArchitecture.Application.Validators.User;
using CleanCodeArchitecture.Domain.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CleanCodeArchitecture.Application.Tests.Commands.Person;

[TestFixture]
[TestOf(typeof(CreatePersonCommandHandler))]
public class CreatePersonCommandHandlerTest
{

    private Mock<IPersonRepository> _personRepositoryMock = new();
    private IServiceCollection _serviceCollection = new ServiceCollection();
    private ServiceProvider _serviceProvider;
    
    [SetUp]
    public void Setup()
    {
        // this._serviceProvider = this._serviceCollection
        //     .AddSingleton<IPersonRepository>(_personRepositoryMock.Object)
        //     .ConfigureServices()
        //     .BuildServiceProvider();
        
        this._serviceProvider = _serviceCollection
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePersonCommandHandler).Assembly))
            .AddSingleton<IPersonRepository>(_personRepositoryMock.Object)
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            // .AddOpenBehavior(typeof(ValidationBehavior<,>))
            .AddValidatorsFromAssembly(typeof(CreatePersonCommandHandler).Assembly)
            .BuildServiceProvider();  
    }
    
    [Test]
    public async Task METHOD()
    {
        // Arrange
        var mediator = this._serviceProvider.GetRequiredService<IMediator>();

        var query = new CreatePersonCommand(string.Empty,string.Empty, string.Empty, null);

        // Act
        var response = await mediator.Send(query);

        // Assert
        // TODO: Validate the Result
    }
    [TearDown]
    public void Dipose()
    {
        this._serviceProvider.Dispose();
    }
}
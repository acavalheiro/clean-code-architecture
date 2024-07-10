using CleanCodeArchitecture.Application.Commands.Person;
using CleanCodeArchitecture.Application.Core.PipelineBehavior;
using CleanCodeArchitecture.Domain.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace CleanCodeArchitecture.Application.Tests.Commands.Person;

[TestFixture]
[TestOf(typeof(CreatePersonCommandHandler))]
public class CreatePersonCommandHandlerTest
{

    private readonly Mock<IPersonRepository> _personRepositoryMock = new();
    private readonly IServiceCollection _serviceCollection = new ServiceCollection();
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
            .AddSingleton(_personRepositoryMock.Object)
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            // .AddOpenBehavior(typeof(ValidationBehavior<,>))
            .AddValidatorsFromAssembly(typeof(CreatePersonCommandHandler).Assembly)
            .AddSingleton<ILoggerFactory, LoggerFactory>()
            .AddSingleton(typeof(ILogger<>), typeof(Logger<>))
            .BuildServiceProvider();  
    }
    
    [Test]
    public async Task CreatePersonCommand_WhenCalled_ReturnsValidationError()
    {
        // Arrange
        var mediator = this._serviceProvider.GetRequiredService<IMediator>();

        var query = new CreatePersonCommand(string.Empty,string.Empty, string.Empty, null);

        // Act
        var response = await mediator.Send(query);

        // Assert
        

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Errors, Is.Not.Null);
        Assert.That(response.Errors.Contains("First name is required."));
        Assert.That(response.Errors.Contains("Last name is required."));
        Assert.That(response.Errors.Contains("Email is required."));
        Assert.That(response.Errors.Contains("Email is not valid."));
 

    }

    [Test]
    public async Task CreatePersonCommand_WhenCalled_CreatePerson()
    {
        // Arrange
        var mediator = this._serviceProvider.GetRequiredService<IMediator>();

        this._personRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Person>())).Returns(Task.FromResult(new Domain.Entities.Person()));

        var query = new CreatePersonCommand("André", "Cavalheiro", "a@a.pt", new DateOnly(1987,11,27));

        // Act
        var response = await mediator.Send(query);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Data,Is.TypeOf<Domain.Entities.Person>());



    }
    [TearDown]
    public void Dispose()
    {
        this._serviceProvider.Dispose();
    }
}
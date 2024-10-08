using CleanCodeArchitecture.Application.Queries.Company;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using CleanCodeArchitecture.Application.Commands.Companiy;

namespace CleanCodeArchitecture.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<CompanyController> _logger;

        public CompanyController(IMediator mediator, ILogger<CompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("List")]
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(new ListCompaniesQuery(), cancellationToken);

            return Ok(result.Value);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Crete(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> List([FromQuery] GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(request, cancellationToken);

            return Ok(result.Value);
        }
    }
}
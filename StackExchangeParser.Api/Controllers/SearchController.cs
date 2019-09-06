namespace StackExchangeParser.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMediator mediator;

        public SearchController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
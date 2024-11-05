#nullable disable

using FriendOrganiser.Application.Features.Friend;
using FriendOrganiser.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FriendOrganiser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public LookupController(IMediator mediator, ILogger<LookupController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("friend-lookup", Name = "GetFriendLookup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<LookupItemViewModel>>> GetFriendLookup(CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(new GetFriendLookup(), cancellationToken: cancellationToken);
            return Ok(queryResponse);
        }

    }
}
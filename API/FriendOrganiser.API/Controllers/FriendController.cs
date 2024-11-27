#nullable disable

using FriendOrganiser.Application.Features.Friend;
using FriendOrganiser.Application.Features.Friend.Commands;
using FriendOrganiser.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FriendOrganiser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public FriendController(IMediator mediator, ILogger<FriendController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("all", Name = "GetAllFriends")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<FriendViewModel>>> GetAllFriends(CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(new GetAllFriends(), cancellationToken: cancellationToken);
            return Ok(queryResponse);
        }

        [HttpGet("{friendId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FriendViewModel>> GetFriendById([FromRoute] int friendId, CancellationToken cancellationToken)
        {
            var queryResponse = await _mediator.Send(new GetFriendById(friendId) , cancellationToken: cancellationToken);
            return Ok(queryResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFriend([FromBody] UpdateFriend.Command request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken: cancellationToken);
            return Ok(response);
        }
    }
}
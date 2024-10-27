#nullable disable

using FriendOrganiser.API.Utility;
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

        //[HttpGet("all", Name = "GetAllFriends")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<List<PartsViewModel>>> GetAllFriends()
        //{
        //    var queryResponse = await _mediator.Send(new GetPartsListQuery());
        //    return Ok(queryResponse);
        //}

    
    }
}
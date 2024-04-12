using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Checkin.DoCheckin;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class CheckInController : ControllerBase
{
    [HttpPost]
    [Route("{attendeeId}/checkin")]
    [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult Checkin([FromRoute] Guid attendeeId)
    {
        var useCase = new DoAttendeeCheckinUseCase();

        var response = useCase.Execute(attendeeId);
        
        return Created(string.Empty, response);
    }
}
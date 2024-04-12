using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Attendees.GetAttendeeById;
using PassIn.Application.UseCases.Attendees.GetAllByEventId;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Application.UseCases.Attendees.RegisterAttendee;

namespace PassIn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class AttendeesController : ControllerBase
{
    [HttpPost]
    [Route("{eventId}/register")]
    [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult Register([FromRoute] Guid eventId, [FromBody] RequestRegisterEventJson request)
    {
        var useCase = new RegisterAttendeeOnEventUseCase();

        var response = useCase.Execute(eventId, request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseAttendeeJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetAttendeeByIdUseCase();

        var response = useCase.Execute(id);

        return Ok(response);
    }

    [HttpGet]
    [Route("{eventId}/all")]
    [ProducesResponseType(typeof(ResponseAllAttendeesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetAllByEventId([FromRoute] Guid eventId)
    {
        var useCase = new GetAllByEventIdUseCase();

        var response = useCase.Execute(eventId);

        return Ok(response);
    }
}

/*

FluentValidation
Automap
Injeção de dependência
AddAsync quando acessar o BD
Localização das mensagens de erro
Guid é só pq é SQLite, geralmente isso é responsabilidade do BD

*/
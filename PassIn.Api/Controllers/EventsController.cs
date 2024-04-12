using Microsoft.AspNetCore.Mvc;
using PassIn.Application;
using PassIn.Application.UseCases.Events.GetById;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class EventsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestEventJson request)
    {
        var useCase = new RegisterEventUseCase();

        var response = useCase.Execute(request);
        
        return Created(string.Empty, response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetEventByIdUseCase();

        var response = useCase.Execute(id);

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
Testes de unidade
Projeto domínio ficou faltando

*/
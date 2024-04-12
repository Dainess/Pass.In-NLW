using System.Net.Mail;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Attendees.RegisterAttendee;

public class RegisterAttendeeOnEventUseCase
{
    private readonly PassInDbContext _dbContext;
    public RegisterAttendeeOnEventUseCase()
    {
        _dbContext = new PassInDbContext();
    }
    public ResponseRegisteredJson Execute(Guid eventId, RequestRegisterEventJson request)
    {
        Validate(eventId, request);

        var entity = new Infrastructure.Entities.Attendee{
            Name = request.Name,
            Email = request.Email,
            Event_Id = eventId,
            Created_At = DateTime.UtcNow
        };

        _dbContext.Attendees.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseRegisteredJson{
            Id = entity.Id
        };
    }

    private void Validate(Guid eventId, RequestRegisterEventJson request)
    {
        //var eventExist = _dbContext.Events.Any(ev => ev.Id == eventId);
        //tivemos que mandar essa linha ir de base pq precisamos do evento lá na frente

        var eventEntity = _dbContext.Events.Find(eventId);
        if (eventEntity is null)
            throw new NotFoundException("An event with this id does not exist.");
        
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ErrorOnValidationException("The name is invalid.");

        if (EmailIsValid(request.Email) == false)
            throw new ErrorOnValidationException("The e-mail is invalid.");

        var alreadyRegistered = _dbContext
            .Attendees
            .Any(at => at.Email.Equals(request.Email) && at.Event_Id == eventId);

        if (alreadyRegistered)
            throw new ConflictException("There is already an attendee registered with this e-mail.");

        int attendees = _dbContext.Attendees.Count(at => at.Event_Id == eventId);
        if (attendees >= eventEntity.Maximum_Attendees)
        {
            throw new ConflictException("The event is at maximum capacity.");
        }
    }

    private bool EmailIsValid(string email)
    {
        try 
        {
            new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
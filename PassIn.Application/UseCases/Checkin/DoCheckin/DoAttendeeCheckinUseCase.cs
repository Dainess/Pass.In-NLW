using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Checkin.DoCheckin;

public class DoAttendeeCheckinUseCase
{
    private readonly PassInDbContext _dbContext;
    public DoAttendeeCheckinUseCase()
    {
        _dbContext = new PassInDbContext();
    }
    public ResponseRegisteredJson Execute(Guid attendeeId)
    {
        Validate(attendeeId);

        var entity = new CheckIn
        {
            Attendee_Id = attendeeId,
            Created_at = DateTime.UtcNow,

        };

        _dbContext.Checkins.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseRegisteredJson{
            Id = entity.Id
        };
    }

    private void Validate(Guid attendeeId)
    {
        var existsAttendee = _dbContext.Attendees.Any(at => at.Id == attendeeId);
        if (existsAttendee == false)
        {
            throw new NotFoundException("The attendee with this Id was not found");
        }

        var existsCheckin = _dbContext.Checkins.Any(chk => chk.Attendee_Id == attendeeId);
        if (existsCheckin)
        {
            throw new ConflictException("Double check ins are not allowed");
        }
    }

}
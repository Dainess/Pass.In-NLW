using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Attendees.GetAttendeeById;

public class GetAttendeeByIdUseCase
{
    private readonly PassInDbContext _dbContext;
    public GetAttendeeByIdUseCase()
    {
        _dbContext = new PassInDbContext();
    }
    public ResponseAttendeeJson Execute(Guid id)
    {
        var entity = _dbContext.Attendees.Include(at => at.CheckIn).FirstOrDefault(at => at.Id == id);
        if (entity is null)
            throw new NotFoundException("An attendee with this id does not exist.");

        return new ResponseAttendeeJson 
        { 
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            Created_At = entity.Created_At.ToLocalTime(),
            Checked_In_At = entity.CheckIn?.Created_at.ToLocalTime(),
        };
    }
}
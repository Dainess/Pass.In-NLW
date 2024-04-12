using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Attendees.GetAllByEventId;

public class GetAllByEventIdUseCase
{
    private readonly PassInDbContext _dbContext;
    public GetAllByEventIdUseCase()
    {
        _dbContext = new PassInDbContext();
    }
    public ResponseAllAttendeesJson Execute(Guid eventId)
    {
        var entity = _dbContext.Events.Include(ev => ev.Attendees).ThenInclude(att => att.CheckIn).FirstOrDefault(ev => ev.Id == eventId);
        if (entity is null)
            throw new NotFoundException("This event was not found.");
        
        //ClassApplication.RodaGenerico(entity);

        return new ResponseAllAttendeesJson
        {
            Attendees = entity.Attendees.Select(attendee => new ResponseAttendeeJson
            {
                Id = attendee.Id,
                Name = attendee.Name,
                Email = attendee.Email,
                Created_At = attendee.Created_At.ToLocalTime(),
                Checked_In_At = attendee.CheckIn?.Created_at.ToLocalTime(),
            }).ToList()
        };
    }

    public ResponseAllAttendeesJson Execute_Alternative(Guid eventId)
    {
        //var attendee = _dbContext.Attendees.Where(attendee => attendee.Event_Id == eventId);

        var eventExists = _dbContext.Events.Find(eventId);
        if (eventExists is null)
            throw new NotFoundException("This event was not found.");

        var entity = _dbContext.Attendees.ToList();

        var returnJson = new ResponseAllAttendeesJson(); 

        foreach (var item in entity)
        {
            if (item.Event_Id == eventId)
                returnJson.Attendees.Add(new ResponseAttendeeJson {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Created_At = item.Created_At.ToLocalTime(),     
                });
        }

        return returnJson;
    }
}
using PassIn.Communication.Responses;
using PassIn.Infrastructure;

namespace PassIn.Application;
public class ClassApplication
{
    public static void RodaFulano(ResponseEventJson response)
    {
        using (StreamWriter writer = new StreamWriter("this.txt"))
        {
            writer.WriteLine($"Title: {response.Title}");
            writer.WriteLine($"Details: {response.Details}");
            writer.WriteLine($"Event Id: {response.Id}");
            writer.WriteLine($"Attendees: {response.AttendeesAmount}");
            writer.WriteLine($"Maximum capacity: {response.MaximumAttendees}");
        }
    }

    public static void RodaGenerico(Infrastructure.Entities.Event evento)
    {
        string soma = "Attendees: [\n";
        foreach (var entity in evento.Attendees)
        {
            soma += "{" + $"{entity.Id}, \n{entity.Name}, \n{entity.Email}, \n{entity.Event_Id}, \n{entity.Created_At}" + "}\n";
        }
        soma += "}";
        Console.WriteLine(soma);
        using (StreamWriter writer = new StreamWriter("this.txt"))
        {
            writer.WriteLine($"Title: {evento.Title}");
            writer.WriteLine($"Details: {evento.Details}");
            writer.WriteLine($"Event Id: {evento.Id}");
            writer.WriteLine($"Attendees: {soma}");
            writer.WriteLine($"Maximum capacity: {evento.Maximum_Attendees}");
        }
    }

    public static void ConectaDB(PassInDbContext dbContext)
    {
        var something = dbContext.Database.CanConnect();
        Console.WriteLine(something);
    }
}

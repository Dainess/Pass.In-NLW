namespace PassIn.Communication.Responses;
public class ResponseAttendeeJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime Created_At { get; set; }
    public DateTime? Checked_In_At { get; set; }
}

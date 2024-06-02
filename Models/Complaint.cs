using complaintApp.Enums;

namespace complaintApp.Models;

public class Complaint
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Customer Customer { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
}
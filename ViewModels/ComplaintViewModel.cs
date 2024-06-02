using complaintApp.Enums;
using complaintApp.Models;

namespace complaintApp.ViewModels;

public class ComplaintViewModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public CustomerViewModel Customer { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }

    public ComplaintViewModel() { }

    public ComplaintViewModel(Complaint complaint)
    {
        Id = complaint.Id;
        ProductId = complaint.ProductId;
        Customer = new CustomerViewModel(complaint.Customer);
        Date = complaint.Date;
        Description = complaint.Description;
        Status = complaint.Status;
    }
}

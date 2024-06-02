using System.ComponentModel.DataAnnotations;
using complaintApp.Models;

namespace complaintApp.ViewModels;

public class CustomerViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }

    public CustomerViewModel() { }

    public CustomerViewModel(Customer customer)
    {
        Id = customer.Id;
        Name = customer.Name;
        Email = customer.Email;
    }
}

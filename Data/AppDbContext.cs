using complaintApp.Models;
using Microsoft.EntityFrameworkCore;

namespace complaintApp.Data;

public class AppDbContext: DbContext
{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Complaint> Complaints { get; set; } public DbSet<Customer> Customers { get; set; }
}
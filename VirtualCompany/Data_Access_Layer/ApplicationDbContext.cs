using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualCompany.Data_Access_Layer.Entities;

namespace VirtualCompany.Data_Access_Layer
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Option):base(Option)
        {

        }



        public DbSet<Employee> employees { get; set; }
        public DbSet<Depender> dependers { get; set; }
    }
}

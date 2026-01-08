using DotnetCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreWebApi.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Login> Logins { get; set; }




    }
}

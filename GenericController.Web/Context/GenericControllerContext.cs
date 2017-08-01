using Microsoft.EntityFrameworkCore;

namespace GenericController.Context
{
    public class GenericControllerContext : DbContext
    {
        public GenericControllerContext(DbContextOptions<GenericControllerContext> options) : base(options)
        {
        }

        public DbSet<Models.Form> Form { get; set; }
        public DbSet<Models.FormInput> FormInput { get; set; }
        public DbSet<Models.Input> Input { get; set; }
        public DbSet<Models.InputProperty> InputProperty { get; set; }        
    }
}
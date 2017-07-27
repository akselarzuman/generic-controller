using Microsoft.EntityFrameworkCore;

namespace GenericVC.Context
{
    public class GenericVCContext : DbContext
    {
        public GenericVCContext(DbContextOptions<GenericVCContext> options) : base(options)
        {
        }

        public DbSet<Models.Form> Form { get; set; }
        public DbSet<Models.FormInput> FormInput { get; set; }
        public DbSet<Models.Input> Input { get; set; }
        public DbSet<Models.InputProperty> InputProperty { get; set; }        
    }
}
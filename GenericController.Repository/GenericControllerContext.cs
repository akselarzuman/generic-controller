using Microsoft.EntityFrameworkCore;
using GenericController.Entities;

namespace GenericController.Repository
{
    public class GenericControllerContext : DbContext
    {
        public GenericControllerContext(DbContextOptions<GenericControllerContext> options) : base(options)
        {
        }

        public DbSet<Form> Form { get; set; }
        public DbSet<FormInput> FormInput { get; set; }
        public DbSet<Input> Input { get; set; }
        public DbSet<InputProperty> InputProperty { get; set; }        
    }
}
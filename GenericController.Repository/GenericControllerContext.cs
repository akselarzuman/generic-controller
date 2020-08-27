using Microsoft.EntityFrameworkCore;
using GenericController.Repository.Entities;

namespace GenericController.Repository
{
    public class GenericControllerContext : DbContext
    {
        public GenericControllerContext(DbContextOptions<GenericControllerContext> options) : base(options)
        {
        }

        public DbSet<FormEntity> Forms { get; set; }

        public DbSet<FormInputEntity> FormInputs { get; set; }
        
        public DbSet<InputEntity> Inputs { get; set; }
        
        public DbSet<InputPropertyEntity> InputProperties { get; set; }        
    }
}
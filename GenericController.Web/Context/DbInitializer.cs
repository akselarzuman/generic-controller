using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GenericController.Repository;

namespace GenericController.Context
{
    public class DbInitializer
    {
        public static readonly DbInitializer Instance = new DbInitializer();

        public void EnsureCreted(IServiceProvider serviceProvider)
        {
            var context = new GenericControllerContext(
                serviceProvider.GetRequiredService<DbContextOptions<GenericControllerContext>>()
                );
            context.Database.EnsureCreated();
        }
    }
}
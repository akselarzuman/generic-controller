using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenericVC.Context
{
    public class DbInitializer
    {
        public static readonly DbInitializer Instance = new DbInitializer();

        public void EnsureCreted(IServiceProvider serviceProvider)
        {
            var context = new GenericVCContext(
                serviceProvider.GetRequiredService<DbContextOptions<GenericVCContext>>()
                );
            context.Database.EnsureCreated();
        }
    }
}
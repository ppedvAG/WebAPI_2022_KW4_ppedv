using Microsoft.Extensions.DependencyInjection;
using System;

namespace Default_WebAPI_Project_NET5.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //var context = serviceProvider.GetRequiredService<WebMarksDbContext>();
            //context.Database.EnsureCreated();
            //if (!context.Tenants.Any())
            //{
            //    context.Tenants.Add(new Tenant() { Name = "Hello", Host = "hello", Style = "red.css" });
            //    context.Tenants.Add(new Tenant() { Name = "Sample", Host = "sample", Style = "blue.css" });
            //    context.SaveChanges();
            //}
        }
    }
}

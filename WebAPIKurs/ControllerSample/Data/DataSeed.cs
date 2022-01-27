using ControllerSample.Models;

namespace ControllerSample.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<MovieDbContext>();
            //context.Database.EnsureCreated();
            if (!context.Movie.Any())
            {
                context.Movie.Add(new Movie() { Title = "Jurassic Park", Description = "T-Rex wird zu Veggie gesüchtet", Price = 10 });
                context.Movie.Add(new Movie() { Title = "Batman", Description = "Batman und Harley Quinn beziehen eine WG", Price = 9.99m });
                context.SaveChanges();
            }
        }
    }
}

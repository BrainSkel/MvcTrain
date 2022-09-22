using Microsoft.EntityFrameworkCore;
using MvcTrains.Data;

namespace MvcTrains.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            Random rnd = new Random();
            using (var context = new MvcTrainsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTrainsContext>>()))
            {
                if (context.Train.Any())
                {
                    return;   // DB has been seeded
                }

                context.Train.AddRange(
                    new Train
                    {
                        Stops = 5, 
                        Speed = ((164 / (rnd.Next(50, 200))) * 60 + 5),
                        WifiPassword = "Romantic Comedy"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

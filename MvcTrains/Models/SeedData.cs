using Microsoft.EntityFrameworkCore;
using MvcTrains.Data;

namespace MvcTrains.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
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
                        Destination = "Tartu",
                        Speed = 70,
                        Stops = 21,
                        WifiPassword = "HelloWorld"
                    }
                    
                );
                context.SaveChanges();
            }
        }
    }
}

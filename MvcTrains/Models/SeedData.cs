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
                       Destination = "Tallinn",
                       Speed = 70,
                       Stops = 10,
                       WifiPassword = ""
                   },
                   new Train
                   {
                       Destination = "OPa",
                       Speed = 50,
                       Stops = 13,
                       WifiPassword = "OpAdeeZNuts23"
                   },
                   new Train
                   {
                       Destination = "Tartu",
                       Speed = 80,
                       Stops = 16,
                       WifiPassword = ""
                   },
                   new Train
                   {
                       Destination = "Tartu",
                       Speed = 64,
                       Stops = 15,
                       WifiPassword = "EnglishManWalks21"
                   }
               );
                context.SaveChanges();
            }
        }
    }
}

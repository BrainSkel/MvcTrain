

namespace MvcTrains.Models
{
    public class Train
    {

        public int Id { get; set; }

        public string? Destination { get; set; }
        public int Speed { get; set; }

        public int Stops { get; set; }

        public string? WifiPassword { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace MvcTrains.Models
{
    public class TrainStopViewModel
    {
        public List<Train>? Trains { get; set; }
        public SelectList? Stops { get; set; }
        public string? TrainStops { get; set; }
        public string? SearchString { get; set; }
    }
}

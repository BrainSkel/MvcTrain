using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTrains.Models
{
    public class Train
    {

        public int Id { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Display(Name = "Destination")]
        [StringLength(128, MinimumLength = 3)]
        [Required]
        public string? Destination { get; set; }

        [Display(Name ="Speed")]
        [Required]
        public int Speed { get; set; }

        [Display(Name = "Stops")]
        [Required]
        public int Stops { get; set; }

        [Display(Name ="Wifi password")]
        [StringLength(16, MinimumLength = 5)]
        public string? WifiPassword { get; set; }

    }
}

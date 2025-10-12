using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EZTix.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        [Display(Name = "Venue")]                // used co pilot to look into changing these for ui
        public string VenueName { get; set; } = string.Empty;

        [Display(Name = "Location")]  
        public string VenueLocation { get; set; } = string.Empty;

        public List<Show>? Shows { get; set; }
    }
}

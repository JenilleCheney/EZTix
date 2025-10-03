namespace EZTix.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        public string VenueName { get; set; } = string.Empty;

        public string VenueLocation { get; set; } = string.Empty;

        public List<Show>? Shows { get; set; }
    }
}

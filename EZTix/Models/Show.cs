namespace EZTix.Models
{
    public class Show
    {
        public int ShowID { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ShowTime  { get; set; }

        public string Owner { get; set; } = string.Empty;

        public DateTime Created { get; set; }


        public int CategoryId { get; set; }
        public int VenueId { get; set; }

        public Category? Category { get; set; }
        public Venue? Venue { get; set; }

    }
}

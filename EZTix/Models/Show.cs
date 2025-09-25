namespace EZTix.Models
{
    public class Show
    {
        public int EventID { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EventTime  { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Owner { get; set; } = string.Empty;

        public DateTime Created { get; set; }


        public int CategoryId { get; set; }

        public Category? Category { get; set; }

    }
}

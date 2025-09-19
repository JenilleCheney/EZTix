namespace EZTix.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public List<Event>? Events { get; set; } 
    }
}

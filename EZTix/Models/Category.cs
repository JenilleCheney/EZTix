using System.ComponentModel.DataAnnotations;

namespace EZTix.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; } = string.Empty;

        public List<Show>? Shows { get; set; } 
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZTix.Models
{
    public class Show
    {
        public int ShowID { get; set; }

        public string Title { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:MMMM d yyyy  h:mm tt}", ApplyFormatInEditMode = true)]

        [Display(Name ="Show Date & Time")]
        public DateTime ShowTime  { get; set; }

        public string Owner { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:MMMM d yyyy  h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        public Category? Category { get; set; }
        public Venue? Venue { get; set; }

        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? FormFile { get; set; } // nullable

    }
}

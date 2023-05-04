using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Models
{
    public class BookReadingEventModel
    {
        [Key]
        [DisplayName("Title *")]
        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter event date and time")]
        [DisplayName("Date *")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter event location")]
        [DisplayName("Location *")]
        public string Location { get; set; }

        [Display(Name = "Start Time *")]
        [Required]
        public string StartTime { get; set; }
        public string Type { get; set; } = "Public";
        [Range(1, 4, ErrorMessage = "Value cannot be more than 4 hrs and less than 1 hr")]
        public int? Duration { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        [StringLength(500)]
        public string? Other { get; set; }
        [Display(Prompt = "comma seperated email list")]
        public string? InviteByMail { get; set; }

        public string Organizer { get; set; }

        public List<CommentModel> Comments { get; set; }
    }
}

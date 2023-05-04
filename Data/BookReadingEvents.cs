using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Data
{

    public class BookReadingEvents
    {
        [Key]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string StartTime { get; set; }
        public string Type { get; set; } = "Public";
        [Range(0, 4)]
        public int? Duration { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        [StringLength(500)]
        public string? Other { get; set; }
        public string? InviteByMail { get; set; }

        public string Organizer { get; set; }

        public List<Comments> Comments { get; set; }
    }
}

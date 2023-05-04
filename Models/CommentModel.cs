using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Enter a comment")]
        public string Comment { get; set; }

        public string EventTitle{ get; set; }

        [ForeignKey("EventTitle")]
        [Required]
        public BookReadingEventModel bookReadingEvent { get; set; }

    }
}

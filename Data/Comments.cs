using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Data
{
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Enter a comment")]
        public string Comment { get; set; }

        public string EventTitle { get; set; }

        [ForeignKey("EventTitle")]
        [Required]
        public BookReadingEvents bookReadingEvent { get; set; }

    }
}

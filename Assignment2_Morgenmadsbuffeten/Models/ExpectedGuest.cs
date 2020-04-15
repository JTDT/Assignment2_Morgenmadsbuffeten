using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_Morgenmadsbuffeten.Models
{
    public class ExpectedGuest
    {
        public long ExpectedGuestId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public int Adults { get; set; }
        [Required]
        public int Children { get; set; }
    }
}

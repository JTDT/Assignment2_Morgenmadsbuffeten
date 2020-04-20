using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_Morgenmadsbuffeten.Models
{
    public class GuestViewModel
    {
        public IEnumerable<CheckedInGuest> CheckedInGuests { get; set; }
        public int ExpectedChildren { get; set; }
        public int ExpectedAdults { get; set; }
        public int CheckedInChildren { get; set; }

        public int CheckedInAdults { get; set; }

        public DateTime GuestDate { get; set; }

        public IEnumerable<ExpectedGuest> ExpectedGuests { get; set; }
        
    }
}

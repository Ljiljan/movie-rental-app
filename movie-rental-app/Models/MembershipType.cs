using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movie_rental_app.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte MonthlyDuration { get; set; }
        public byte Discount { get; set; }
    }
}
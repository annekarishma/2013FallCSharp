using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManagement.Models
{
   public  class Contact
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        
        public Int64 MobileNumber { get; set; }

        public string EmailId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}

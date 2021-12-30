using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_Notes.Models
{
    public class User
    {
        
        public string EmailId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

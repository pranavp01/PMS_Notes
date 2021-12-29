using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_Notes.Models
{
    public class User
    {
        public int Id { get; set; }
        public List<Notes> Notes { get; set; }
    }
}

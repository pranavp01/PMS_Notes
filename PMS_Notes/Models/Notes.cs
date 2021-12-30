using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_Notes.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int UserId { get; set; }
        public int ReceiverId { get; set; }
        public int IsUrgent { get; set; }
        public int IsCancelled { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Response { get; set; }
        public string Designation { get; set; }

    }
}

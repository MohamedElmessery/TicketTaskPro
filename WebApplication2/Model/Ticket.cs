using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Ticket
    {
        [Key]
        public int Tic_Id { get; set; }
        public string Tic_Name { get; set; }
        public DateTime Creationdatetime { get; set; }
        public bool Status { get; set; }
        public string Content { get; set; }
        public DateTime Laststatuschangesdatetime { get; set; }
        public bool Userassigned { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}

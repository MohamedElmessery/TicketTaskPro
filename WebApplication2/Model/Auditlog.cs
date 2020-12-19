using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model
{
    public class Auditlog
    {
        [Key]
        public int Aud_id { get; set; }
        
       
        public string Action { get; set; }
        
        
        public DateTime Datetime { get; set; }
        public virtual  User User { get; set; }
        public virtual Ticket  Ticket { get; set; }
    }
}

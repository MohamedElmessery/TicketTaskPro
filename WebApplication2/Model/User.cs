using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Ticket> Tickets{ get; set; }
    }
}

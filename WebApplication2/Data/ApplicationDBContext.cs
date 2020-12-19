using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> contextOptions) : base(contextOptions)
        {
        }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User>  Users { get; set; }
        public virtual DbSet<Auditlog>  Auditlogs { get; set; }
    }
}

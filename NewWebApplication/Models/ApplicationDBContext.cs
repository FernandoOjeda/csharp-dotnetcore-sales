using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebApplication.Models
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            :base(options)
        {

        }
        public DbSet<ObjectData> ObjectData { get; set; }
        public DbSet<ObjectData2> ObjectData2 { get; set; }
    }
}

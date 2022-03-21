#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bug_Tracker.Models;

namespace Bug_Tracker.Data
{
    public class Bug_TrackerContext : DbContext
    {
        public Bug_TrackerContext (DbContextOptions<Bug_TrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Bug_Tracker.Models.BugModel> BugModel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PickinTunes.Models
{
    public class PickinTunesContext : DbContext
    {
        public PickinTunesContext(DbContextOptions<PickinTunesContext> options) : base(options) { }

        public DbSet<Tune> Tune { get; set; }
    }
}

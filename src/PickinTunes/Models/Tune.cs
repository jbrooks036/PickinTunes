using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PickinTunes.Models
{
    public class Tune
    {
        public int TuneId { get; set; }
        public int TuneTitle { get; set; }
    }
}

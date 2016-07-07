using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PickinTunes.Models
{
    public class Tune
    {
        [Key]
        public int TuneId { get; set; }
        public string TuneTitle { get; set; }

        [ForeignKey("ArtistId")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}

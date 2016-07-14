using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PickinTunes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace PickinTunes.Controllers
{
    [Route("api/artist")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class ArtistController : Controller
    {
        private PickinTunesContext _context;

        public ArtistController(PickinTunesContext context)
        {
            _context = context;
        }

        // GET api/artist
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Artist> artist = from a in _context.Artist
                                    select a;

            return Ok(artist);
        }

        // GET api/artist/5
        [HttpGet("{id}", Name = "GetArtist")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Artist artist = _context.Artist.Single(m => m.ArtistId == id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // POST api/artist
        [HttpPost]
        [EnableCors("AllowDevelopmentEnvironment")]
        public IActionResult AddArtist([FromBody]Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Artist.Add(artist);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("GetArtist", new { id = artist.ArtistId }, artist);
        }

    }
}

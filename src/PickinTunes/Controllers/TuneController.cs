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
    [Route("api/tune")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class TuneController : Controller
    {
        private PickinTunesContext _context;

        public TuneController(PickinTunesContext context)
        {
            _context = context;
        }

        // GET api/tune
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Tune> tunes = from t in _context.Tune
                                     join a in _context.Artist on t.ArtistId equals a.ArtistId
                                     select new Tune
                                     {
                                         TuneId = t.TuneId,
                                         TuneTitle = t.TuneTitle,
                                         ArtistId = t.ArtistId,
                                         Artist = a
                                     };

            return Ok(tunes);
        }

        // GET api/tune/5
        [HttpGet("{id}", Name = "GetTune")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tune tune = _context.Tune.Single(m => m.TuneId == id);

            if (tune == null)
            {
                return NotFound();
            }

            return Ok(tune);
        }

        // POST api/tune
        [HttpPost]
        [EnableCors("AllowDevelopmentEnvironment")]
        public IActionResult AddTune([FromBody]Tune tune)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tune.Add(tune);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("GetTune", new { id = tune.TuneId }, tune);
        }


        // DELETE api/tune/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tune tune = _context.Tune.Single(m => m.TuneId == id);
            if (tune == null)
            {
                return NotFound();
            }

            _context.Tune.Remove(tune);
            _context.SaveChanges();

            return Ok(tune);
        }

        private bool TuneExists(int id)
        {
            return _context.Tune.Count(e => e.TuneId == id) > 0;
        }

    }

}


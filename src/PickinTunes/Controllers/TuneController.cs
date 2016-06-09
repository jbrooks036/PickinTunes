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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class TuneController : Controller
    {
        private PickinTunesContext _context;

        public TuneController(PickinTunesContext context)
        {
            _context = context;
        }

        // GET api/tunes
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Tune> tune = from t in _context.Tune
                                              select t;

            return Ok(tune);
        }

        // GET api/values/5
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

        // POST api/tunes
        [HttpPost]
        public IActionResult Post([FromBody]Tune tune)
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
                if (TuneExists(tune.TuneId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTune", new { id = tune.TuneId }, tune);
        }

        private bool TuneExists(int id)
        {
            return _context.Tune.Count(e => e.TuneId == id) > 0;
        }

    }

}


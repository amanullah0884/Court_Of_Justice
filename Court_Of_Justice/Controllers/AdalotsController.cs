using Court_Of_Justice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Court_Of_Justice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdalotsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public AdalotsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Adalot> Get()
        {
            return _context.Adalot.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Adalot> Get(int id)
        {
            var adalot = _context.Adalot.Find(id);
            if (adalot == null)
            {
                return NotFound();
            }
            return Ok(adalot);
        }
        [HttpPost]
        public IActionResult Post(Adalot adalot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Adalot.Add(adalot);
            _context.SaveChanges();
            return CreatedAtRoute(new { id = adalot.ID }, adalot);
        }

        [HttpPut]
        public IActionResult Put(int id, Adalot adalot)
        {
            var existingAdalot = _context.Adalot.Find(id);
            if (existingAdalot == null)
            {
                return NotFound();
            }
            existingAdalot.Name = adalot.Name;
            existingAdalot.Description = adalot.Description;
            _context.SaveChanges();
            return Ok(existingAdalot);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var adalot = _context.Adalot.Find(id);
            if (adalot == null)
            {
                return NotFound();
            }

            _context.Adalot.Remove(adalot);
            _context.SaveChanges();
            return Ok();
        }

    }

}

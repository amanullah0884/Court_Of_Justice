using Court_Of_Justice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Court_Of_Justice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseMastersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CaseMastersController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public IEnumerable<CaseMaster> Get()
        {
            return _context.CaseMasters.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<CaseMaster>GetAll(int id)
        {
            var CaseM = _context.CaseMasters.Find(id);
            if(CaseM == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(CaseM);
            }

        }
        [HttpPost]
        public ActionResult Post(CaseMaster caseMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.CaseMasters.Add(caseMaster);
            _context.SaveChanges();
            return CreatedAtRoute(new { id = caseMaster.ID }, caseMaster);

        }

        [HttpPut]
        public IActionResult Put(int id, CaseMaster caseMaster)
        {
            var existingCaseM = _context.CaseMasters.Find(id);
            if (existingCaseM == null)
            {
                return NotFound();
            }
            existingCaseM.ID = caseMaster.ID;
            existingCaseM.Description = caseMaster.Description;
            _context.SaveChanges();
            return Ok(existingCaseM);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var caseM = _context.CaseMasters.Find(id);
            if (caseM == null)
            {
                return NotFound();
            }

            _context.CaseMasters.Remove(caseM);
            _context.SaveChanges();
            return Ok();
        }

    }
}

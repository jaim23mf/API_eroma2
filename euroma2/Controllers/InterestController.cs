using euroma2.Models;
using euroma2.Models.Interest;
using euroma2.Models.Promo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace euroma2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {

        private readonly DataContext _dbContext;
        public InterestController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<InterestController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interest_model>>> Get()
        {
            if (_dbContext.interests == null)
            {
                return NotFound();
            }
            var t = await _dbContext
                .interests
                .ToListAsync();

            if (t == null)
            {
                return NotFound();
            }

            return t;
        }


        [HttpGet("InterestMobile")]
        public async Task<ActionResult<IEnumerable<Interest_View>>> GetIn()
        {
            if (_dbContext.interests == null)
            {
                return NotFound();
            }
            var t = await _dbContext
                .interests
                .ToListAsync();

            if (t == null)
            {
                return NotFound();
            }

            List<Interest_View> liv = new List<Interest_View>();
            for (int i = 0; i < t.Count; i++) { 
                Interest_View inter = new Interest_View();
                inter.id = t[i].id;
                inter.name = t[i].name;

                var st = (Interest_Group)t[i].group;
                inter.group = st.ToString();

                liv.Add(inter);
            }

            return liv;
        }

        // GET api/<InterestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interest_model>> GetInterest(int id)
        {
            if (_dbContext.interests == null)
            {
                return NotFound();
            }
            var t = await _dbContext
                .interests
                .FirstOrDefaultAsync(p => p.id == id); ;

            if (t == null)
            {
                return NotFound();
            }

            return t;
        }

        // POST api/<InterestController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Interest_model>> Post( Interest_model interest)
        {
            _dbContext.interests.Add(interest);
            await _dbContext.SaveChangesAsync();
            //return CreatedAtAction(nameof(GetShop), new { id = shop.id }, shop);
            return CreatedAtAction(nameof(GetInterest), new { id = interest.id }, interest);
        }

        // PUT api/<InterestController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutInterest(int id, Interest_model interest)
        {
            if (id != interest.id)
            {
                return BadRequest();
            }

            _dbContext.Entry(interest).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok(new PutResult { result = "Ok" });
        }

        private bool InterestExists(long id)
        {
            return (_dbContext.interests?.Any(e => e.id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            if (_dbContext.interests == null)
            {
                return NotFound();
            }
            var ss = await _dbContext.interests.FindAsync(id);
            if (ss == null)
            {
                return NotFound();
            }
            _dbContext.interests.Remove(ss);
            await _dbContext.SaveChangesAsync();
            return Ok(new PutResult { result = "Ok" });
        }
    }
}

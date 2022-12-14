using euroma2.Models.Interest;
using euroma2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using euroma2.Models.Reach;
using Microsoft.AspNetCore.Authorization;
using euroma2.Services;
using Microsoft.Extensions.Options;

namespace euroma2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReachController : ControllerBase
    {
        private readonly DataContext _dbContext;
        private readonly PtaInfo _options;
        public ReachController(DataContext dbContext, IOptions<PtaInfo> options)
        {
            _dbContext = dbContext;
            _options = options.Value;
        }

        // GET: api/<InterestController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reach_Us>>> Get()
        {
            if (_dbContext.reach == null)
            {
                return NotFound();
            }
            var t = await _dbContext
                .reach
                .ToListAsync();

            if (t == null)
            {
                return NotFound();
            }

            return t;
        }

        // GET api/<InterestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reach_Us>> GetReach(int id)
        {
            if (_dbContext.interests == null)
            {
                return NotFound();
            }
            var t = await _dbContext
                .reach
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
        public async Task<ActionResult<Reach_Us>> Post(Reach_Us reach)
        {
            _dbContext.reach.Add(reach);
            await _dbContext.SaveChangesAsync();
            //return CreatedAtAction(nameof(GetShop), new { id = shop.id }, shop);
            return CreatedAtAction(nameof(GetReach), new { id = reach.id }, reach);
        }

        // PUT api/<InterestController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutReach(int id, Reach_Us reach)
        {
            if (id != reach.id)
            {
                return BadRequest();
            }

            _dbContext.Entry(reach).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReachExists(id))
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

        private bool ReachExists(long id)
        {
            return (_dbContext.reach?.Any(e => e.id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteReach(int id)
        {
            if (_dbContext.reach == null)
            {
                return NotFound();
            }
            var ss = await _dbContext.reach.FindAsync(id);
            if (ss == null)
            {
                return NotFound();
            }
            _dbContext.reach.Remove(ss);
            await _dbContext.SaveChangesAsync();
            return Ok(new PutResult { result = "Ok" });
        }


        [HttpPost("ImgUpload/{id}")]
        [Authorize]
        public async Task<IActionResult> UploadToFileSystem(IFormFile file, int id)
        {
            UploadFiles uf = new UploadFiles(this._options);
            uf = await uf.UploadFileToAsync(Consts.ReachImg, file);
            return Ok(uf);
        }
    }
}

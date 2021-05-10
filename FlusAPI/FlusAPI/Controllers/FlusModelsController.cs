using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlusAPI.Model;
using Flus.Model;

namespace FlusAPI.Controllers
{
    [Route("api/FlusAPIModels")]
    [ApiController]
    public class FlusModelsController : ControllerBase
    { 
        private readonly FlusContext _context;

        public FlusModelsController(FlusContext context)
        {
            _context = context;
        }

        // GET: api/FlusModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlusModel>>> GetFlusModel()
        {
            return await _context.FlusModels.ToListAsync();
        }

        // GET: api/FlusModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlusModel>> GetFlusModel(long id)
        { 
            var flusModel = await _context.FlusModels.FindAsync(id);

            if (flusModel == null)
            {
                return NotFound();
            }

            return flusModel;
        }

        // PUT: api/FlusModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlusModel(long id, FlusModel flusModel)
        {
            if (id != flusModel.id)
            {
                return BadRequest();
            }

            _context.Entry(flusModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlusModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FlusModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FlusModel>> PostFlusModel(FlusModel flusModel)
        {
            _context.FlusModels.Add(flusModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlusModel), new { id = flusModel.id }, flusModel);
        }

        // DELETE: api/FlusModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FlusModel>> DeleteFlusModel(long id)
        {
            var flusModel = await _context.FlusModels.FindAsync(id);
            if (flusModel == null)
            {
                return NotFound();
            }

            _context.FlusModels.Remove(flusModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlusModelExists(long id)
        {
            return _context.FlusModels.Any(e => e.id == id);
        }
    }
}

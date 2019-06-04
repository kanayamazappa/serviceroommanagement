using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementsController : ControllerBase
    {
        private readonly RoomManagementContext _context;

        public ManagementsController(RoomManagementContext context)
        {
            _context = context;
        }

        // GET: api/Managements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Management>>> GetManagements()
        {
            return await _context.Managements.Include(m => m.Room).Include(m => m.User).Include(m => m.ManagementSchedules).ToListAsync();
        }

        // GET: api/Managements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Management>> GetManagement(int id)
        {
            var management = await _context.Managements.Include(m => m.Room).Include(m => m.User).Include(m => m.ManagementSchedules).Where(m => m.IdManagement == id).FirstOrDefaultAsync();

            if (management == null)
            {
                return NotFound();
            }

            return management;
        }

        // PUT: api/Managements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagement(int id, Management management)
        {
            if (id != management.IdManagement)
            {
                return BadRequest();
            }

            var listIdSchedule = await _context.ManagementSchedules.Where(ms => ms.Management.IdManagement != management.IdManagement && ms.Management.Date == management.Date && ms.Management.IdRoom == management.IdRoom).Select(ms => ms.IdSchedule).ToListAsync<int>();
            if (management.ManagementSchedules.Where(ms => listIdSchedule.Contains(ms.IdSchedule)).Count() > 0)
            {
                return BadRequest("Existe um agendamento para esta sala neste período.");
            }

            var lstMsAux = await _context.ManagementSchedules.Where(ms => ms.IdManagement == id && !management.ManagementSchedules.Contains(ms)).ToListAsync();
            _context.ManagementSchedules.RemoveRange(lstMsAux);
            foreach (var item in management.ManagementSchedules)
            {
                item.IdManagement = management.IdManagement;
                _context.ManagementSchedules.Add(item);
            }

            _context.Entry(management).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagementExists(id))
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

        // POST: api/Managements
        [HttpPost]
        public async Task<ActionResult<Management>> PostManagement(Management management)
        {
            var listIdSchedule = await _context.ManagementSchedules.Where(ms => ms.Management.Date == management.Date && ms.Management.IdRoom == management.IdRoom).Select(ms => ms.IdSchedule).ToListAsync<int>();
            if (management.ManagementSchedules.Where(ms => listIdSchedule.Contains(ms.IdSchedule)).Count() > 0)
            {
                return BadRequest("Existe um agendamento para esta sala neste período.");
            }

            _context.Managements.Add(management);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagement", new { id = management.IdManagement }, management);
        }

        // DELETE: api/Managements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Management>> DeleteManagement(int id)
        {
            var management = await _context.Managements.FindAsync(id);
            if (management == null)
            {
                return NotFound();
            }

            _context.Managements.Remove(management);
            await _context.SaveChangesAsync();

            return management;
        }

        private bool ManagementExists(int id)
        {
            return _context.Managements.Any(e => e.IdManagement == id);
        }
    }
}

﻿using System;
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
            return await _context.Managements.ToListAsync();
        }

        // GET: api/Managements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Management>> GetManagement(int id)
        {
            var management = await _context.Managements.FindAsync(id);

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
            try
            {
                _context.Managements.Add(management);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetManagement", new { id = management.IdManagement }, management);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

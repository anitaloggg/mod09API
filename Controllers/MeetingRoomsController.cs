using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mod09API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mod09API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly MeetingRoomContext _context;

        public MeetingRoomsController(MeetingRoomContext context)
        {
            _context = context;
        }
        // GET: MeetingRooms  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetMeetingRooms()
        {
            return await _context.MeetingRooms.ToListAsync();
        }

        // GET: api/MeetingRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingRoom>> GetMeetingRoom(int id)
        {
            var meetingRoom = await _context.MeetingRooms.FindAsync(id);
            if (meetingRoom == null)
            {
                return NotFound();
            }
            return meetingRoom;
        }

        // POST: api/MeetingRooms 
        [HttpPost]
        public async Task<ActionResult<MeetingRoom>> PostMeetingRoom(MeetingRoom meetingRoom)
        {
            _context.MeetingRooms.Add(meetingRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeetingRoom", new { id = meetingRoom.ID }, meetingRoom);
        }


        // PUT <MeetingRoomsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingRoom(int id, MeetingRoom meetingRoom)
        {
            if (id != meetingRoom.ID) return BadRequest();
            _context.Entry(meetingRoom).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingRoomExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }
        private bool MeetingRoomExists(int id)
        {
            return _context.MeetingRooms.Any(e => e.ID == id);
        }


        // DELETE <MeetingRoomsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeetingRoom>> DeleteMeetingRoom(int id)
        {
            var meetingRoom = await _context.MeetingRooms.FindAsync(id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            _context.MeetingRooms.Remove(meetingRoom);
            await _context.SaveChangesAsync();

            return meetingRoom;
        }

    }
}

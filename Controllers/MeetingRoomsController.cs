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


        // POST api/<MeetingRoomsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MeetingRoomsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeetingRoomsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

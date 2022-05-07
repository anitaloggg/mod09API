using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mod09API.Model
{
    public class MeetingRoomContext : DbContext
    {
        public MeetingRoomContext(
DbContextOptions<MeetingRoomContext> options) : base(options)
        { }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }

    }
}

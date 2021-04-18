using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlTest.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Speaker> Speakers { get; set; } = default!;
        public DbSet<Track> Tracks { get; set; } = default!;
        public DbSet<Session> Sessions { get; set; } = default!;
        public DbSet<Attendee> Attendees { get; set; } = default!;

    }
}

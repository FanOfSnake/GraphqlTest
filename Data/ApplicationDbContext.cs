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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>()
                .HasIndex(a => a.UserName)
                .IsUnique();

            modelBuilder.Entity<SessionAttendee>()
                .HasKey(k => new { k.SessionId, k.AttendeeId });

            modelBuilder.Entity<SessionSpeaker>()
                .HasKey(k => new { k.SessionId, k.SpeakerId });
        }

        public DbSet<Speaker> Speakers { get; set; } = default!;
        public DbSet<Track> Tracks { get; set; } = default!;
        public DbSet<Session> Sessions { get; set; } = default!;
        public DbSet<Attendee> Attendees { get; set; } = default!;

    }
}

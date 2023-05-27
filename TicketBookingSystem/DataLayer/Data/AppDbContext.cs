using EntityLibrary.ClientClasses;
using EntityLibrary.EventClasses;
using EntityLibrary.TicketClasses;
using EntityLibrary.UserClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventType> EventTypes { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<AgeLimit> AgeLimits { get; set; } = null!;
        public DbSet<Organizer> Organizers { get; set; } = null!;


        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().Navigation(e => e.EventAgeLimit).AutoInclude();
            modelBuilder.Entity<Event>().Navigation(e => e.EventType).AutoInclude();
            modelBuilder.Entity<Event>().Navigation(e => e.EventLocation).AutoInclude();
            modelBuilder.Entity<Event>().Navigation(e => e.EventOrganizer).AutoInclude();
            modelBuilder.Entity<Ticket>().Navigation(t => t.TicketCategory).AutoInclude();
            modelBuilder.Entity<Ticket>().Navigation(t => t.TicketStatus).AutoInclude();
            modelBuilder.Entity<Ticket>().Navigation(t => t.Event).AutoInclude();
        }
    }
}

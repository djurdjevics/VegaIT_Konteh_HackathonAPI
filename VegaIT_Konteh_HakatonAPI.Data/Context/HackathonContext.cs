using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaIT_Konteh_HakatonAPI.Data.Entities;

namespace VegaIT_Konteh_HakatonAPI.Data.Context
{
    public class HackathonContext:DbContext
    {
        public HackathonContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Desk> Desks { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //WorkingHours->Faculty Relation
            modelBuilder.Entity<WorkingHours>()
                .HasMany(x => x.Faculties)
                .WithOne(x => x.WorkingHours)
                .IsRequired();
            //Faculty->WorkingHours Relation
            modelBuilder.Entity<Faculty>()
                .HasOne(x => x.WorkingHours)
                .WithMany(x => x.Faculties)
                .HasForeignKey(x=>x.WorkingHour)
                .IsRequired();

            //Room->Faculty Relation
            modelBuilder.Entity<Room>()
                .HasOne(x => x.Faculty)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.FacultyID)
                .IsRequired();

            //Faculty->Room Relation
            modelBuilder.Entity<Faculty>()
                .HasMany(x => x.Rooms)
                .WithOne(x => x.Faculty)
                .IsRequired();

            //Room->Desk Relation
            modelBuilder.Entity<Room>()
                .HasMany(x => x.Desks)
                .WithOne(x => x.Room)
                .IsRequired();

            //Desk->Room Relation
            modelBuilder.Entity<Desk>()
                .HasOne(x => x.Room)
                .WithMany(x => x.Desks)
                .HasForeignKey(x=>x.RoomID)
                .IsRequired();
        }
    }
}

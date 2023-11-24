using Microsoft.EntityFrameworkCore;
using NoteProject.DAL.Model;
using NoteProjectDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Kullanici> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-EVCENE1; Initial Catalog = NoteAppDB; User Id = sa; Password = Anyela123");


            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new KullaniciMapping().Configure(modelBuilder.Entity<Kullanici>());
            new NoteMapping().Configure(modelBuilder.Entity<Note>());
            //base.OnModelCreating(modelBuilder);
        }
    }
}

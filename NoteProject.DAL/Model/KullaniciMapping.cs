using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteProjectDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.DAL.Model
{
    public class KullaniciMapping : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            // Requireds
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x =>x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);

            builder.Property(x => x.IsActive).HasColumnName("IsActive");

            // Table Name
            builder.ToTable("Users");

            // Seed Data
            builder.HasData
                (
                    new Kullanici
                    {
                        Id = 1,
                        FirstName = "Admin",
                        LastName = "Admin",
                        UserName = "admin",
                        Password = "admin123",
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    }
                );
                
                    
                

            
        }
    }
}

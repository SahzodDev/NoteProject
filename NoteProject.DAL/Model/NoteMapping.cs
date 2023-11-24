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
    public class NoteMapping : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            // Table Name
            builder.ToTable("Notes");

            // Requireds
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);

            // Relations
            builder.HasOne(x => x.User).WithMany(x => x.Notes).HasForeignKey(x => x.UserRefId);
            
        }
    }
}

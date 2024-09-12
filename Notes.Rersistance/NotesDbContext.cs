using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Rersistance.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Rersistance
{
    public class NotesDbContext : DbContext, INotesDBContext
    {
        public DbSet<Note> Notes { get ; set ; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistance;

namespace Common
{
    public static class NotesContextFactory
    {
        public static Guid UseAId = Guid.NewGuid();
        public static Guid UseBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange
            (
                new Note
                {
                    CreationDate = DateTime.Now,
                    Details = "Details1",
                    EditDate = null,
                    Id = Guid.Parse("DC965839-8FF5-4FA2-A60D-8D5D71A4498B"),
                    Title = "Title1",
                    UserId = UseAId
                },
                new Note
                {
                    CreationDate = DateTime.Now,
                    Details = "Details2",
                    EditDate = null,
                    Id = Guid.Parse("3AC22CAF-5997-4C3C-BA84-1E2F7495C21E"),
                    Title = "Title2",
                    UserId = UseBId
                },
                new Note
                {
                    CreationDate = DateTime.Now,
                    Details = "Details3",
                    EditDate = null,
                    Id = NoteIdForDelete,
                    Title = "Title3",
                    UserId = UseAId
                },
                new Note
                {
                    CreationDate = DateTime.Now,
                    Details = "Details4",
                    EditDate = null,
                    Id = NoteIdForUpdate,
                    Title = "Title4",
                    UserId = UseBId
                }
            );
            context.SaveChanges();
            return context;
        }
        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

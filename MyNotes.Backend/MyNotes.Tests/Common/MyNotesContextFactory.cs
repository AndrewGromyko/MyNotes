using Microsoft.EntityFrameworkCore;
using MyNotes.Domain.Interfaces;
using MyNotes.Domain.Models;
using MyNotes.Persistence;

namespace MyNotes.Tests.Common
{
    public class MyNotesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new NotesDbContext(options);

            context.Database.EnsureCreated();
            context.Notes.AddRange(
                new Note
                {
                    Title = "Title1",
                    Details = "Details1",
                    Id = Guid.Parse("B888D1A1-4ECB-4598-B058-044A6B99C250"),
                    UserId = UserAId,
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    Title = "Title2",
                    Details = "Details2",
                    Id = Guid.Parse("B6F5B5FF-988E-4B84-980A-3ACEB8DE1D65"),
                    UserId = UserBId,
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    Title = "Title3",
                    Details = "Details3",
                    Id = NoteIdForDelete,
                    UserId = UserAId,
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    Title = "Title4",
                    Details = "Details4",
                    Id = NoteIdForUpdate,
                    UserId = UserBId,
                    CreationDate = DateTime.Today,
                    EditDate = null
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

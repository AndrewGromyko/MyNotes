using Microsoft.EntityFrameworkCore;
using MyNotes.Application.Notes.Commands.CreateNote;
using MyNotes.Domain.Interfaces;
using MyNotes.Domain.Interfaces.Repositories;
using MyNotes.Domain.Models.Commands;
using MyNotes.Tests.Common;

namespace MyNotes.Tests.Notes.Commands
{
    public class CreateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateNoteCommandHandler((INotesDbContext)Context);
            var noteName = "note name";
            var noteDetails = "note details";

            //Act
            var noteId = await handler.Handle(
                new CreateNoteCommand
                {
                    Title = noteName,
                    Details = noteDetails,
                    UserId = MyNotesContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Notes.SingleOrDefaultAsync(note =>
                note.Id == noteId &&
                note.Title == noteName &&
                note.Details == noteDetails));
        }
    }
}

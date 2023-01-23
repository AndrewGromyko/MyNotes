using Microsoft.EntityFrameworkCore;
using MyNotes.Application.Common.Exceptions;
using MyNotes.Application.Notes.Commands.UpdateNote;
using MyNotes.Domain.Models.Commands;
using MyNotes.Tests.Common;

namespace MyNotes.Tests.Notes.Commands
{
    public class UpdateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateNoteCommandHandler((Domain.Interfaces.INotesDbContext)Context);
            var updatedTitle = "Updated Title";

            //Act
            await handler.Handle(new UpdateNoteCommand
            {
                Id = MyNotesContextFactory.NoteIdForUpdate,
                UserId = MyNotesContextFactory.UserBId,
                Title = updatedTitle
            }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Notes.SingleOrDefaultAsync(note =>
                note.Id == MyNotesContextFactory.NoteIdForUpdate &&
                note.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateNoteCommandHandler(Context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateNoteCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = MyNotesContextFactory.UserAId
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            //Arrange
            var handler = new UpdateNoteCommandHandler(Context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateNoteCommand
                    {
                        Id = MyNotesContextFactory.NoteIdForUpdate,
                        UserId = MyNotesContextFactory.UserAId
                    }, CancellationToken.None));
        }
    }
}

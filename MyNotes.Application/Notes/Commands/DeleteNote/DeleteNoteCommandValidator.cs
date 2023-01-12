using FluentValidation;

namespace MyNotes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(DeleteNoteCommand =>
                DeleteNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(DeleteNoteCommand =>
                DeleteNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}

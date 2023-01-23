using FluentValidation;
using MyNotes.Domain.Models.Commands;

namespace MyNotes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(UpdateNoteCommand =>
                UpdateNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(UpdateNoteCommand =>
                UpdateNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(UpdateNoteCommand =>
                UpdateNoteCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}

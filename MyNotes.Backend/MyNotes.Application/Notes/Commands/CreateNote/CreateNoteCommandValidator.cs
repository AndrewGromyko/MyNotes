using FluentValidation;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MyNotes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(CreateNoteCommand =>
                CreateNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(CreateNoteCommand =>
                CreateNoteCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}

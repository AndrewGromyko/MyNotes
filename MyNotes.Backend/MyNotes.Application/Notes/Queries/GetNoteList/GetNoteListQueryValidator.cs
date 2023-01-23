using FluentValidation;
using MyNotes.Domain.Models.Commands;

namespace MyNotes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(list => list.UserId).NotEqual(Guid.Empty);
        }
    }
}

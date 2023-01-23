using MediatR;
using MyNotes.Domain.Models.Views;

namespace MyNotes.Domain.Models.Commands
{
    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}

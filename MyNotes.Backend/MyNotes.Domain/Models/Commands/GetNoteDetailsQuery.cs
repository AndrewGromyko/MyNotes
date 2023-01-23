using MediatR;
using MyNotes.Domain.Models.Views;

namespace MyNotes.Domain.Models.Commands
{
    public class GetNoteDetailsQuery : IRequest<NoteDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}

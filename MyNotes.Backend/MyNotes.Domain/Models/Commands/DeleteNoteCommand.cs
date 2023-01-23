using MediatR;

namespace MyNotes.Domain.Models.Commands
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}

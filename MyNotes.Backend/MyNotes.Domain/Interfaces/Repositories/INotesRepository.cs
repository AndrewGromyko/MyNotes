using Microsoft.EntityFrameworkCore;
using MyNotes.Domain.Models;
using MyNotes.Domain.Models.Commands;

namespace MyNotes.Domain.Interfaces.Repositories
{
    public interface INotesRepository
    {
        Task CreateNoteAsync(Note note,
            CancellationToken cancellationToken);

        Task<Note> FindNoteAsync(DeleteNoteCommand request,
            CancellationToken cancellationToken);

        Task DeleteNoteAsync(Note note,
            CancellationToken cancellationToken);
    }
}

using Microsoft.EntityFrameworkCore;
using MyNotes.Domain.Models;

namespace MyNotes.Domain.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

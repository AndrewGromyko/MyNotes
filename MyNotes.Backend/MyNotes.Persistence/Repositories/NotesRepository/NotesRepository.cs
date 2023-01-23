using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MyNotes.Domain.Interfaces;
using MyNotes.Domain.Interfaces.Repositories;
using MyNotes.Domain.Models;
using MyNotes.Domain.Models.Commands;
using System.Threading;

namespace MyNotes.Persistence.Repositories.NotesRepository
{
    public class NotesRepository : INotesRepository
    {
        private INotesDbContext _dbContext;
        public NotesRepository(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateNoteAsync(Note note,
            CancellationToken cancellationToken)
        {
            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Note> FindNoteAsync(DeleteNoteCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
            .FindAsync(new object[] { request.Id }, cancellationToken);

            return entity;
        }

        public async Task DeleteNoteAsync(Note note,
            CancellationToken cancellationToken)
        {
            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
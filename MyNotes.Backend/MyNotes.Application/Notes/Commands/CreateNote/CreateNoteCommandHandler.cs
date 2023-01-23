using MediatR;
using MyNotes.Domain.Interfaces;
using MyNotes.Domain.Interfaces.Repositories;
using MyNotes.Domain.Models;
using MyNotes.Domain.Models.Commands;
using MyNotes.Persistence.Repositories.NotesRepository;

namespace MyNotes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler
        : IRequestHandler<CreateNoteCommand, Guid>
    {
        private INotesRepository _repository;

        public CreateNoteCommandHandler(INotesDbContext dbContext)
        {
            _repository = new NotesRepository(dbContext);
        }

        public async Task<Guid> Handle(CreateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _repository.CreateNoteAsync(note, cancellationToken);

            return note.Id;
        }
    }
}

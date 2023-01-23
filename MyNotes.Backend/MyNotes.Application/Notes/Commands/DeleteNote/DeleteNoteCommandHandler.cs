using MediatR;
using MyNotes.Application.Common.Exceptions;
using MyNotes.Domain.Interfaces;
using MyNotes.Domain.Interfaces.Repositories;
using MyNotes.Domain.Models;
using MyNotes.Domain.Models.Commands;
using MyNotes.Persistence.Repositories.NotesRepository;

namespace MyNotes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler
        : IRequestHandler<DeleteNoteCommand>
    {
        private INotesRepository _repository;

        public DeleteNoteCommandHandler(INotesDbContext dbContext)
        {
            _repository = new NotesRepository(dbContext);
        }

        public async Task<Unit> Handle(DeleteNoteCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _repository.FindNoteAsync(request, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(Note), request.Id);

            await _repository.DeleteNoteAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}

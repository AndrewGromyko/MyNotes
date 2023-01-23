using AutoMapper;
using MyNotes.Application.Notes.Queries.GetNoteList;
using MyNotes.Domain.Interfaces;
using MyNotes.Domain.Models.Commands;
using MyNotes.Domain.Models.Views;
using MyNotes.Tests.Common;
using Shouldly;

namespace MyNotes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteListQueryHandlerTests
    {
        private readonly INotesDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetNoteListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetNoteListQuery
                {
                    UserId = MyNotesContextFactory.UserBId
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<NoteListVm>();
            result.Notes.Count.ShouldBe(2);
        }
    }
}

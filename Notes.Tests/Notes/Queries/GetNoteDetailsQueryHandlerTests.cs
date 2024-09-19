using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Tests.Common;
using Xunit;
using Notes.Rersistance;
using Common;
using Shouldly;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        private readonly NotesDbContext Context;
        private readonly IMapper Mapper;
        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNoteDetailsQueryHandler(Context, Mapper);
            // Act
            var result = await handler.Handle(
                new GetNotesDetailsQuery
                {
                    UserId = NotesContextFactory.UserBId,
                    Id = Guid.Parse("BDEF47B9-7944-44F5-82F5-A1D788E731C4")
                },
                CancellationToken.None);
            // Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
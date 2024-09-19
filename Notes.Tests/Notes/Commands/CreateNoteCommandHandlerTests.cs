using Common;
using Notes.Application.Notes.Commands.CreateNote;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Notes.Tests.Notes.Commands
{
    public class CreateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateNoteCommandHandler(_context);
            var noteName = "note name";
            var noteDetails = "note details";
            // Act
            var noteId = await handler.Handle(
                new CreateNoteCommand
                {
                    Title = noteName,
                    Details = noteDetails,
                    UserId = NotesContextFactory.UseAId
                },
                CancellationToken.None);
            // Assert
            Assert.NotNull(
                await _context.Notes.SingleOrDefaultAsync(note =>
                    note.Id == noteId && note.Title == noteName &&
                    note.Details == noteDetails));
        }
    }
}

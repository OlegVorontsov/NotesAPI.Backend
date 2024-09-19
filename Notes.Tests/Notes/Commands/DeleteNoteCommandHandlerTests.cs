using Common;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exeptions;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Notes.Tests.Notes.Commands
{
    public class DeleteNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteNoteCommandHandler(_context);
            // Act
            var noteId = await handler.Handle(
                new DeleteNoteCommand
                {
                    Id = NotesContextFactory.NoteIdForDelete,
                    UserId = NotesContextFactory.UserAId,
                }, CancellationToken.None);
            // Assert
            Assert.Null(
                await _context.Notes.SingleOrDefaultAsync(note =>
                    note.Id == NotesContextFactory.NoteIdForDelete));
        }
        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            // Arange
            var handler = new DeleteNoteCommandHandler(_context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteNoteCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = NotesContextFactory.UserAId
                    },
                    CancellationToken.None));
        }
        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteNoteCommandHandler(_context);
            var createHandler = new CreateNoteCommandHandler(_context);
            var noteId = await createHandler.Handle(
                new CreateNoteCommand
                {
                    Title = "NoteTitle",
                    UserId = NotesContextFactory.UserAId
                }, CancellationToken.None);
            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteNoteCommand
                    {
                        Id = noteId,
                        UserId = NotesContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}

using FluentValidation;
using Notes.Application.Notes.Commands.UpdateNote;
using System;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteCommand =>
                updateNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}

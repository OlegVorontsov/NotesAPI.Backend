using FluentValidation;
using Notes.Application.Notes.Queries.GetNoteList;
using System;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}

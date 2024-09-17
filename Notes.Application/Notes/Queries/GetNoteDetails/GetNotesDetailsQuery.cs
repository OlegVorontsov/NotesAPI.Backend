using MediatR;
using System;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNotesDetailsQuery : IRequest<NoteDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}

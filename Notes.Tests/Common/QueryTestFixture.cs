using AutoMapper;
using System;
using Notes.Application.Interfaces;
using Xunit;
using Notes.Rersistance;
using Common;
using Notes.Application.Common.Mappings;

namespace Notes.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public NotesDbContext Context;
        public IMapper Mapper;
        public QueryTestFixture()
        {
            Context = NotesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssymblyMappingProfile(
                    typeof(INotesDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }
        public void Dispose()
        {
            NotesContextFactory.Destroy(Context);
        }
    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Notes.Application.Common.Mappings
{
    public class AssymblyMappingProfile : Profile
    {
        // assymbly - ссылка на сборку
        public AssymblyMappingProfile(Assembly assymbly) =>
            ApplyMappingsFromAssembly(assymbly);

        private void ApplyMappingsFromAssembly(Assembly assymbly)
        {
            var types = assymbly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }

    }
}

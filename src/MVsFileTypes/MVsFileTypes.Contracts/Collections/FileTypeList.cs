using System.Linq;
using System.Collections.Generic;

namespace MVsFileTypes.Contracts.Collections
{
    public class FileTypeList
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<FileTypeGroup> Groups { get; set; }

        public FileTypeList ConcatWith(FileTypeList list)
            => new FileTypeList()
            {
                Name = Name,
                Description = Description,
                Groups = Groups
                    .Concat(list.Groups)
                    .Distinct()
                    .ToArray()
            };

        public FileTypeList Filter(IEnumerable<string> fileExtensions, FilterOptions filterOptions)
        {
            var list = new FileTypeList()
            {
                Name = Name,
                Description = Description,
                Groups = Groups
                    .Select(g => g.Filter(fileExtensions, FilterOptions.None))
                    .Where(g => g.FileTypes.Any())
                    .ToArray()
            };

            if (filterOptions == FilterOptions.ThrowOnNotFoundItems)
            {
                var diff = fileExtensions.Where(
                    extension => list.Groups
                    .All(group => group.FileTypes.All(type => !type.Extension.Matches(extension))))
                    .ToArray();
                if (diff.Any())
                    throw Throwable.ExtensionNotFound(diff.Length, diff.FirstOrDefault());
            }

            return list;
        }
    }
}

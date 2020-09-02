using System.Linq;
using System.Collections.Generic;
using MVsFileTypes.Contracts.Collections;

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
            => new FileTypeList()
            {
                Name = Name,
                Description = Description,
                Groups = Groups
                    .Select(g => g.Filter(fileExtensions, filterOptions))
                    .Where(g => g.FileTypes.Any())
                    .ToArray()
            };
    }
}

using System.Linq;
using System.Collections.Generic;

namespace MVsFileTypes.Contracts.Collections
{
    public class FileTypeGroup
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public IEnumerable<FileType> FileTypes { get; set; }

        public FileTypeGroup Filter(IEnumerable<string> fileExtensions, FilterOptions filterOptions)
            => Filter(Name, ID, fileExtensions, filterOptions);

        public FileTypeGroup Filter(string name, string id, IEnumerable<string> fileExtensions, FilterOptions filterOptions)
        {
            IEnumerable<FileType> filterMethod(IEnumerable<string> extensions)
            {
                var matched = FileTypes.Where(type => extensions.Any(type.Extension.Matches)).ToArray();

                if (filterOptions == FilterOptions.ThrowOnNotFoundItems)
                {
                    var diff = extensions.Where(e => !matched.Any(m => m.Extension.Matches(e))).ToArray();
                    if (diff.Length > 0)
                        throw Throwable.ExtensionNotFound(diff.Length, diff.FirstOrDefault());
                }

                return matched;
            }

            return new FileTypeGroup()
            {
                Name = name,
                ID = id,
                FileTypes = filterMethod(fileExtensions)
            };
        }
    }
}

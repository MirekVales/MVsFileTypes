using System.Linq;
using MVsFileTypes.Contracts;
using System.Collections.Generic;
using MVsFileTypes.Contracts.Collections;

namespace MVsFileTypes.Contracts
{
    public class ExtensionDetail
    {
        public string Extension { get; set; }
        public IEnumerable<FileType> MatchingFileTypes { get; set; }
        public IEnumerable<FileTypeGroup> MatchingGroups { get; set; }

        public bool IsEmpty =>
            (!MatchingFileTypes?.Any() ?? true)
            && (!MatchingGroups?.Any() ?? true);

        public ExtensionDetail MergeWith(ExtensionDetail detail)
            => new ExtensionDetail()
            {
                Extension = Extension,
                MatchingFileTypes = MatchingFileTypes.Concat(detail.MatchingFileTypes).ToArray(),
                MatchingGroups = MatchingGroups.Concat(detail.MatchingGroups).ToArray()
            };
    }
}

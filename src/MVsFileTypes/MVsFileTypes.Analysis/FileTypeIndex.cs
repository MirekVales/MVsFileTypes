using System.Linq;
using MVsFileTypes.Contracts;
using System.Collections.Generic;
using MVsFileTypes.Contracts.Collections;

namespace MVsFileTypes.Analysis
{
    class FileTypeIndex
    {
        readonly Dictionary<string, FileType[]> typeIndex;
        readonly Dictionary<string, FileTypeGroup[]> groupIndex;

        public FileTypeIndex(FileTypeList list)
        {
            var groupedCombinations = list
                .Groups
                .SelectMany(group => group
                    .FileTypes
                    .SelectMany(type => type
                        .Extension
                        .FileExtensions
                        .Select(extension => (group, type, extension))))
                .GroupBy(combination => combination.extension)
                .ToArray();

            typeIndex = groupedCombinations
                .ToDictionary(
                    combination => combination.Key
                    , combination => combination.Select(c => c.type).ToArray());
            groupIndex = groupedCombinations
                .ToDictionary(
                    combination => combination.Key
                    , combination => combination.Select(c => c.group).ToArray());
        }

        internal ExtensionDetail GetDetail(string fileExtension)
        {
            var extension = fileExtension.Trim('.').ToLower();
            return new ExtensionDetail()
            {
                Extension = extension,
                MatchingFileTypes =
                    typeIndex.TryGetValue(extension, out var fileTypes)
                    ? fileTypes.ToArray()
                    : Enumerable.Empty<FileType>(),
                MatchingGroups =
                    groupIndex.TryGetValue(extension, out var groups)
                    ? groups.ToArray()
                    : Enumerable.Empty<FileTypeGroup>()
            };
        }
    }
}

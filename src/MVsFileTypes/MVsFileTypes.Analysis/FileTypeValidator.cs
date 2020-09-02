using MVsFileTypes.Contracts.Validation;
using MVsFileTypes.Analysis;
using MVsFileTypes.Contracts.Collections;
using MVsFileTypes.Contracts.Validation;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVsFileTypes.Validator
{
    public class FileTypeValidator
    {
        public FileTypeList FileTypesList { get; }
        public ValidationMode ValidationMode { get; set; }

        readonly FileTypeIndex index;

        public FileTypeValidator(FileTypeList list, ValidationMode mode)
        {
            FileTypesList = list;
            ValidationMode = mode;

            index = new FileTypeIndex(list);
        }

        public ValidationResult Validate(FileInfo fileInfo)
            => Validate(fileInfo.Extension);

        public ValidationResult Validate(string extension)
            => Validate(new[] { extension });

        public ValidationResult Validate(IEnumerable<string> extensions)
        {
            var incidents = extensions
                .Select(name => name.Trim('.').ToLower())
                .Select(name =>
                    ValidationMode == ValidationMode.Whitelist
                    ? GetWhitelistIncidents(index, name)
                    : GetBlacklistIncidents(index, name))
                .Where(incident => incident != null);

            return new ValidationResult()
            {
                Incidents = incidents.ToArray()
            };
        }

        ValidationIncident GetWhitelistIncidents(FileTypeIndex index, string extension)
        {
            var detail = index.GetDetail(extension);
            return detail.IsEmpty
                ? new ValidationIncident()
                {
                    Extension = extension,
                }
                : null;
        }

        ValidationIncident GetBlacklistIncidents(FileTypeIndex index, string extension)
        {
            var detail = index.GetDetail(extension);
            return detail.IsEmpty
                ? null
                : new ValidationIncident()
                {
                    Extension = extension,
                    FileTypes = detail.MatchingFileTypes.ToArray(),
                    Groups = detail.MatchingGroups.ToArray()
                };
        }
    }
}

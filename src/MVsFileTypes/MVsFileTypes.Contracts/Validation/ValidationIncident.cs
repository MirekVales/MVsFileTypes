using System.Collections.Generic;
using MVsFileTypes.Contracts.Collections;

namespace MVsFileTypes.Contracts.Validation
{
    public class ValidationIncident
    {
        public string Extension { get; set; }
        public ValidationMode ValidationMode { get; set; }
        public IEnumerable<FileType> FileTypes { get; set; }
        public IEnumerable<FileTypeGroup> Groups { get; set; }
    }
}

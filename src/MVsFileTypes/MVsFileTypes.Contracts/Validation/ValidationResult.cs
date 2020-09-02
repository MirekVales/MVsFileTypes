using System.Linq;
using System.Collections.Generic;

namespace MVsFileTypes.Contracts.Validation
{
    public class ValidationResult
    {
        public IEnumerable<ValidationIncident> Incidents { get; set; }

        public bool IsSuccess => !Incidents?.Any() ?? true;
    }
}

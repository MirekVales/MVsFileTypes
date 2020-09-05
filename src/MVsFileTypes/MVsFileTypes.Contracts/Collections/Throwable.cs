using System;
using System.Collections.Generic;

namespace MVsFileTypes.Contracts.Collections
{
    internal static class Throwable
    {
        internal static Exception ExtensionNotFound(int length, string exemplarExtension)
            => new KeyNotFoundException($"{length} extension(s) was not found in list. E.g. {exemplarExtension}");
    }
}

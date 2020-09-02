using System;

namespace MVsFileTypes.Contracts
{
    [Flags]
    public enum FileTypeFlags
    {
        Legacy = 1,

        Android = 16,
        Unix = 32,
        MacOS = 64,
        Windows = 128,
        OS2 = 256
    }
}

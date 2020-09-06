using System;
namespace MVsFileTypes.Contracts
{
    [Flags]
    public enum SignatureType
    {
        Unknown = 0,

        Executable = 1,

        Zip = 2,
        Bzip2 = 4,
        GZip = 8,
        Tar = 16,
        Rar = 32,

        CompoundFileBinary = 2048,
        PDF = 4096,
        MicrosoftOfficeDocument = 8192,
    }
}

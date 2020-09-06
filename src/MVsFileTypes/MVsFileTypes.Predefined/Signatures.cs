using MVsFileTypes.Contracts;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined
{
    public static class Signatures
    {
        public static IEnumerable<FileSignature> Get()
        {
            yield return new FileSignature(SignatureType.CompoundFileBinary, "Compound File Binary", "D0-CF-11-E0-A1-B1-1A-E1", 8);
            yield return new FileSignature(SignatureType.MicrosoftOfficeDocument, "MS Office Document", "50-4B-03-04-14-00-06-00", 8);
            yield return new FileSignature(SignatureType.MicrosoftOfficeDocument, "MS Office Document", "D0-CF-11-E0-A1-B1-1A-E1", 8);
            yield return new FileSignature(SignatureType.Rar, "RAR", "52-61-72-21-1A-07-00", 7);
            yield return new FileSignature(SignatureType.Tar, "Tar", "75-73-74-61-72", 5);
            yield return new FileSignature(SignatureType.PDF, "PDF", "25-50-44-46-2D", 5);
            yield return new FileSignature(SignatureType.Zip, "Zip Bytes", "50-4B-03-04", 4);
            yield return new FileSignature(SignatureType.Zip, "Zip Bytes", "4C-5A-49-50", 4);
            yield return new FileSignature(SignatureType.Zip, "Zip Bytes", "50-4B-05-06", 4);
            yield return new FileSignature(SignatureType.Zip, "Zip Bytes", "50-4B-07-08", 4);
            yield return new FileSignature(SignatureType.Bzip2, "Bzip2 Bytes", "42-5A-68", 3);
            yield return new FileSignature(SignatureType.Tar, "Tar LZH Bytes", "1F-A0", 2);
            yield return new FileSignature(SignatureType.GZip, "GZIP File", "1F-8B", 2);
            yield return new FileSignature(SignatureType.Tar, "Tar LZW", "1F-9D", 2);
            yield return new FileSignature(SignatureType.Executable, "Executable", "4D-5A", 2);
            yield return new FileSignature(SignatureType.Executable, "Executable", "5A-4D", 2);
        }
    }
}

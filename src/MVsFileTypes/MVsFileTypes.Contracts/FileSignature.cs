namespace MVsFileTypes.Contracts
{
    public class FileSignature
    {
        public SignatureType FileType { get; }
        public string Name { get; }
        public string Bytes { get; }
        public int Length { get; }

        public FileSignature(SignatureType fileType, string name, string bytes, int length)
        {
            FileType = fileType;
            Name = name;
            Bytes = bytes;
            Length = length;
        }

        public static FileSignature Unknown
            => new FileSignature(SignatureType.Unknown, nameof(SignatureType.Unknown), "", 0);
    }
}

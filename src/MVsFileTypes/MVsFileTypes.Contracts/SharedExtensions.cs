namespace MVsFileTypes.Contracts
{
    public static class SharedExtensions
    {
        public static FileType Legacy(this FileType fileType)
        {
            fileType.Flags |= FileTypeFlags.Legacy;
            return fileType;
        }

        public static FileType Legacy(this (string, string, string) fileType)
            => Legacy((FileType)fileType);

        public static FileType Flag(this (string, string, string) fileType, FileTypeFlags flag)
        {
            ((FileType)fileType).Flags |= flag;
            return fileType;
        }
    }
}

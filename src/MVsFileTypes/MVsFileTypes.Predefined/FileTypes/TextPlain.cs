using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class TextPlain
    {
        public static string ID = "PTX";
        public static string UserName = "Plain Text Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "txt", "Text File");
            yield return (ID + "02", "utxt", "Unicode Text File");
            yield return (ID + "03", "unx", "Unix Text File").Flag(FileTypeFlags.Unix);
            yield return (ID + "04", "text", "ASCII Text File");
            yield return (ID + "05", "me", "READ.ME File");
            yield return (ID + "06", "log", "Log File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = TextPlain.ID,
                Name = TextPlain.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

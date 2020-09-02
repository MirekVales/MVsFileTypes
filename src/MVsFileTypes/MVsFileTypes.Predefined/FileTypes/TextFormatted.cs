using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class TextFormatted
    {
        public static string ID = "FTX";
        public static string UserName = "Formatted Text Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "csv", "Comma Separated Value File");
            yield return (ID + "02", "xml", "XML File");
            yield return (ID + "03", "xsd", "XML Schema File");
            yield return (ID + "04", "tex", "LaTeX Source File");
            yield return (ID + "05", "srt", "Subtitle File");
            yield return (ID + "06", "sub", "Subtitle File");
            yield return (ID + "07", "rtf", "Rich Text File");
            yield return (ID + "08", "rtx", "Rich Text File");
            yield return (ID + "09", "pdf", "Adobe PDF");
            yield return (ID + "10", "sql", "SQL File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = TextFormatted.ID,
                Name = TextFormatted.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

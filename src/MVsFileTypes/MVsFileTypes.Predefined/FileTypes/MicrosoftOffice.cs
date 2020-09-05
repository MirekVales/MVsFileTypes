using MVsFileTypes.Contracts;
using System.Collections.Generic;
using MVsFileTypes.Contracts.Collections;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class MicrosoftOffice
    {
        public static string ID = "MSO";
        public static string UserName = "Microsoft Office";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "docx", "Microsoft Word Document");
            yield return (ID + "02", "docm", "Microsoft Word Macro-enabled Document");
            yield return (ID + "03", "dotx", "Microsoft Word Template");
            yield return (ID + "04", "dotm", "Microsoft Word Macro-enabled Template");
            yield return (ID + "05", "docb", "Microsoft Word Binary Document");
            yield return (ID + "06", "doc", "Microsoft Word 97 – 2003 Document").Legacy();
            yield return (ID + "07", "dot", "Microsoft Word 97 – 2003 Template").Legacy();
            yield return (ID + "08", "wbk", "Microsoft Word Backup Document").Legacy();
            yield return (ID + "21", "xlsx", "Microsoft Excel Document");
            yield return (ID + "22", "xlsm", "Microsoft Excel Macro-enabled Document");
            yield return (ID + "23", "xltx", "Microsoft Excel Template");
            yield return (ID + "24", "xltm", "Microsoft Excel Macro-enabled Template");
            yield return (ID + "25", "xlsb", "Microsoft Excel Binary Document");
            yield return (ID + "26", "xll", "Microsoft Excel Add-in");
            yield return (ID + "26", "xls", "Microsoft Excel 97 – 2003 Document").Legacy();
            yield return (ID + "27", "xlt", "Microsoft Excel 97 – 2003 Template").Legacy();
            yield return (ID + "28", "xlm", "Microsoft Excel Macro").Legacy();
            yield return (ID + "51", "wps", "Microsoft Works Document").Legacy();
            yield return (ID + "52", "xlr", "Microsoft Works Sheet Document").Legacy();
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = MicrosoftOffice.ID,
                Name = MicrosoftOffice.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

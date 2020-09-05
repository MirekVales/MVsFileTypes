using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class SystemFiles
    {
        public static string ID = "SYS";
        public static string UserName = "System File Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "reg", "Windows Registry File").Flag(FileTypeFlags.Windows);
            yield return (ID + "02", "rgs", "Windows Registry Script File").Flag(FileTypeFlags.Windows);
            yield return (ID + "03", "cur", "Windows Cursor File").Flag(FileTypeFlags.Windows);
            yield return (ID + "04", "cpl", "Windows Control Panel Extension").Flag(FileTypeFlags.Windows);
            yield return (ID + "05", "drv", "Device Driver").Flag(FileTypeFlags.Windows);
            yield return (ID + "06", "hlp", "Help File").Flag(FileTypeFlags.Windows);
            yield return (ID + "07", "hpj", "Help Project File").Flag(FileTypeFlags.Windows);
            yield return (ID + "08", "nt", "Windows NT Start File").Flag(FileTypeFlags.Windows);
            yield return (ID + "09", "swp", "Swap File").Flag(FileTypeFlags.Windows);
            yield return (ID + "10", "sys", "System File").Flag(FileTypeFlags.Windows);
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = SystemFiles.ID,
                Name = SystemFiles.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

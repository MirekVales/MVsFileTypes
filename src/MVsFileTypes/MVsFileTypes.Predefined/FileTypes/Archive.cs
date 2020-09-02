using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class Archive
    {
        public static string ID = "ARC";
        public static string UserName = "Archive File Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "bz2", "bzip2");
            yield return (ID + "02", "gz", "Jgzip");
            yield return (ID + "03", "lz", "lzip");
            yield return (ID + "04", "7z", "7zip");
            yield return (ID + "05", "cab", "Cabinet File");
            yield return (ID + "06", "dmg", "Apple Disk Image");
            yield return (ID + "07", "apk", "Android Application Package");
            yield return (ID + "08", "jar", "Java Application Archive");
            yield return (ID + "09", "rar", "RAR File");
            yield return (ID + "10", "sfx", "Self Extracting Archive");
            yield return (ID + "11", "tar", "Tar");
            yield return (ID + "12", "zip;zipx", "ZIP");
            yield return (ID + "13", "msi", "Windows Installer Package");
            yield return (ID + "14", "arj", "ARJ Package");
            yield return (ID + "15", "deb", "Debian Software Package");
            yield return (ID + "16", "vcd", "Virtual CD");
            yield return (ID + "17", "db;dbf", "Database File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = Archive.ID,
                Name = Archive.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

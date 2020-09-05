using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class Executable
    {
        public static string ID = "EXE";
        public static string UserName = "Executable File Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "exe", "PE File").Flag(FileTypeFlags.Windows);
            yield return (ID + "02", "bat", "Batch File").Flag(FileTypeFlags.Windows);
            yield return (ID + "03", "bin", "Binary Executable File").Flag(FileTypeFlags.Windows | FileTypeFlags.Unix | FileTypeFlags.MacOS);
            yield return (ID + "04", "com", "Command File").Flag(FileTypeFlags.Windows);
            yield return (ID + "05", "cmd", "Command Script").Flag(FileTypeFlags.Windows);
            yield return (ID + "06", "app", "MacOS Application File").Flag(FileTypeFlags.MacOS);
            yield return (ID + "07", "app", "MacOS Application File").Flag(FileTypeFlags.MacOS);
            yield return (ID + "08", "apk", "Android Application File").Flag(FileTypeFlags.Android);
            yield return (ID + "09", "csh", "C Shell Script File").Flag(FileTypeFlags.Unix | FileTypeFlags.MacOS);
            yield return (ID + "10", "inf", "Setup Information File").Flag(FileTypeFlags.Windows);
            yield return (ID + "11", "msi", "Windows Installer Package File").Flag(FileTypeFlags.Windows);
            yield return (ID + "12", "lnk", "File Shortcut").Flag(FileTypeFlags.Windows);
            yield return (ID + "13", "msp", "Windows Installer Patch File").Flag(FileTypeFlags.Windows);
            yield return (ID + "14", "reg", "Windows Registry File").Flag(FileTypeFlags.Windows);
            yield return (ID + "15", "rgs", "Windows Registry Script File").Flag(FileTypeFlags.Windows);
            yield return (ID + "16", "vb", "Visual Basic File").Flag(FileTypeFlags.Windows);
            yield return (ID + "17", "vbe", "Visual Basic File").Flag(FileTypeFlags.Windows);
            yield return (ID + "18", "vbs", "Visual Basic File").Flag(FileTypeFlags.Windows);
            yield return (ID + "19", "vbscript", "Visual Basic File").Flag(FileTypeFlags.Windows);
            yield return (ID + "20", "ws", "Windows Script File").Flag(FileTypeFlags.Windows);
            yield return (ID + "21", "scr", "Windows Screen Saver File").Flag(FileTypeFlags.Windows);
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = Executable.ID,
                Name = Executable.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

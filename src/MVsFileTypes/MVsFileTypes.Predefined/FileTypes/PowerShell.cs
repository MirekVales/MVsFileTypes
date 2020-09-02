using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class PowerShell
    {
        public static string ID = "PSH";
        public static string UserName = "PowerShell File Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "ps1", "PowerShell Script File");
            yield return (ID + "02", "ps1xml", "PowerShell Display Configuration File");
            yield return (ID + "03", "ps2", "PowerShell Script File");
            yield return (ID + "04", "ps2xml", "PowerShell Display Configuration File");
            yield return (ID + "05", "psc1", "PowerShell Console File");
            yield return (ID + "06", "psc2", "PowerShell Console File");
            yield return (ID + "07", "psd1", "PowerShell Data File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = PowerShell.ID,
                Name = PowerShell.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

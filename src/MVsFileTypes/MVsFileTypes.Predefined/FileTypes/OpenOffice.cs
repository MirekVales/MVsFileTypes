using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class OpenOffice
    {
        public static string ID = "AOO";
        public static string UserName = "Apache OpenOffice";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "odt", "OpenOffice Text Document");
            yield return (ID + "02", "ott", "OpenOffice Text Template Document");
            yield return (ID + "03", "odm", "OpenOffice Master Document");
            yield return (ID + "04", "sxw", "OpenOffice.org 1.x Text Document").Legacy();
            yield return (ID + "05", "stw", "OpenOffice.org 1.x Text Document Template").Legacy();
            yield return (ID + "06", "ods", "OpenOffice Spreadsheet Document");
            yield return (ID + "07", "ots", "OpenOffice Spreadsheet Template Document");
            yield return (ID + "08", "odg", "OpenOffice Drawing Document");
            yield return (ID + "09", "otg", "OpenOffice Drawing Template Document");
            yield return (ID + "10", "odp", "OpenOffice Presentation Document");
            yield return (ID + "11", "otp", "OpenOffice Presentation Template Document");
            yield return (ID + "12", "odf", "OpenOffice Formula Document");
            yield return (ID + "13", "odc", "OpenOffice Chart Document");
            yield return (ID + "14", "odb", "OpenOffice Database Document");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = OpenOffice.ID,
                Name = OpenOffice.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

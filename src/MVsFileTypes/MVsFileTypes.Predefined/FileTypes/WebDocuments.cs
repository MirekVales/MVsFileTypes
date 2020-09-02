using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class WebDocuments
    {
        public static string ID = "WEB";
        public static string UserName = "Web Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "asp", "Active Server Page");
            yield return (ID + "02", "aspx", "Active Server Page Extended File");
            yield return (ID + "03", "css", "Cascading Style Sheet");
            yield return (ID + "04", "dcr", "Shockwave Media File");
            yield return (ID + "05", "htm;html", "Hypertext Markup Language File");
            yield return (ID + "06", "js", "JavaScript File");
            yield return (ID + "07", "jsp;jspx", "Java Server Page");
            yield return (ID + "08", "php;php3", "PHP Source Code");
            yield return (ID + "09", "rss", "Rich Site Summary");
            yield return (ID + "10", "xhtm;xhtml", "Hypertext Markup Language Extensible File");
            yield return (ID + "11", "swf", "Shockwave File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = WebDocuments.ID,
                Name = WebDocuments.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

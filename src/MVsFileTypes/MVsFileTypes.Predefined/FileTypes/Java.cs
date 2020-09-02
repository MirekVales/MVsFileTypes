using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class Java
    {
        public static string ID = "JAV";
        public static string UserName = "Java File Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "java", "Java Language File");
            yield return (ID + "02", "jar", "Java Classes Archive File");
            yield return (ID + "03", "js", "JavaScript Code File");
            yield return (ID + "04", "jsp", "Java Server Page File");
            yield return (ID + "05", "jnlp", "Java Network Launch Protocol File");
            yield return (ID + "06", "jad", "Java Application Descriptor File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = Java.ID,
                Name = Java.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

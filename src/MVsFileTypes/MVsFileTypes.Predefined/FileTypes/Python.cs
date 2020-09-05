using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class Python
    {
        public static string ID = "PYT";
        public static string UserName = "Python File Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "py", "Python Script File");
            yield return (ID + "02", "pyc", "Python Compiled Bytecode File");
            yield return (ID + "03", "pyo", "Python Script File").Legacy();
            yield return (ID + "04", "pyw", "Python Script Windows Mode File");
            yield return (ID + "05", "pyz", "Python Script Archive File");
            yield return (ID + "06", "pyzw", "Python Script Windows Mode File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = Python.ID,
                Name = Python.UserName,
                FileTypes = GetFileTypes()
            };
    }
}

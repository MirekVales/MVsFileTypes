using System.Linq;
using System.Collections.Generic;
using MVsFileTypes.Predefined.FileTypes;
using MVsFileTypes.Contracts.Collections;
using MVsFileTypes.Predefined.FileTypes;
using MVsFileTypes.Contracts.Collections;

namespace MVsFileTypes.Predefined.Lists
{
    public static class PredefinedFileTypes
    {
        public static IEnumerable<FileTypeGroup> GetGroups()
        {
            yield return Archive.Get();
            yield return Audio.Get();
            yield return Executable.Get();
            yield return Image.Get();
            yield return Java.Get();
            yield return MicrosoftOffice.Get();
            yield return OpenOffice.Get();
            yield return PowerShell.Get();
            yield return Python.Get();
            yield return Security.Get();
            yield return TextFormatted.Get();
            yield return TextPlain.Get();
            yield return WebDocuments.Get();
        }

        public static FileTypeList Get()
            => new FileTypeList()
            {
                Name = nameof(PredefinedFileTypes),
                Groups = GetGroups().ToArray()
            };
    }
}

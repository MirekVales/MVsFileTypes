using System.IO;
using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;

namespace MVsFileTypes.Analysis
{
    public class FileTypeAnalyzer
    {
        public FileTypeList List { get; }

        readonly FileTypeIndex index;

        public FileTypeAnalyzer(FileTypeList list)
        {
            List = list;
            index = new FileTypeIndex(list);
        }

        public ExtensionDetail Analyze(FileInfo info)
            => index.GetDetail(info.Extension);

        public ExtensionDetail Analyze(string fileName)
            => index.GetDetail(Path.GetExtension(fileName));
    }
}

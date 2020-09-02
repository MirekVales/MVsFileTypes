using System.IO;
using System.Linq;
using MVsFileTypes.Contracts;
using System.Collections.Generic;
using MVsFileTypes.Contracts.Collections;

namespace MVsFileTypes.Analysis
{
    public class FileTypeHistogram
    {
        public int ItemsCount { get; set; }
        public Dictionary<string, (ExtensionDetail Detail, double Frequency)> Frequency { get; set;  }

        public static FileTypeHistogram Generate(FileTypeList list, IEnumerable<string> fileNames)
        {
            var index = new FileTypeIndex(list);
            var itemsCount = fileNames.Count();
            var count = (double)itemsCount;
            var items = fileNames
                .Select(name => Path.GetExtension(name).Trim('.').ToLower())
                .Select(extension => (extension, index.GetDetail(extension)))
                .GroupBy(pair => pair.extension)
                .ToDictionary(
                    group => group.Key
                    , group => 
                        (group.Select(g => g.Item2).Aggregate(group.First().Item2, (first, item) => first.MergeWith(item))
                        , group.Count() / count));

            return new FileTypeHistogram()
            {
                ItemsCount = itemsCount,
                Frequency = items
            };
        }
    }
}

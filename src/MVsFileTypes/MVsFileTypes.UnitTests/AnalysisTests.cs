using System.Linq;
using MVsFileTypes.Analysis;
using MVsFileTypes.Validator;
using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Validation;
using MVsFileTypes.Predefined.FileTypes;
using MVsFileTypes.Contracts.Collections;
using MVsFileTypes.Contracts.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVsFileTypes.UnitTests
{
    [TestClass]
    public class AnalysisTests
    {
        [TestMethod]
        public void Blacklists()
        {
            // Arrange

            var archive = Archive.Get();
            var image = Image.Get();
            var list = new FileTypeList() { Groups = new[] { archive, image } };
            var validator = new FileTypeValidator(list, ValidationMode.Blacklist);

            // Act

            var acceptedExtensionsResult = validator.Validate(Python.GetFileTypes().SelectMany(ft => ft.Extension.FileExtensions));
            var blockedExtensionsResultA = validator.Validate(Archive.GetFileTypes().SelectMany(ft => ft.Extension.FileExtensions));
            var blockedExtensionsResultB = validator.Validate(Image.GetFileTypes().SelectMany(ft => ft.Extension.FileExtensions));


            // Assert

            Assert.IsTrue(acceptedExtensionsResult.IsSuccess);
            Assert.IsFalse(blockedExtensionsResultA.IsSuccess);
            Assert.IsFalse(blockedExtensionsResultB.IsSuccess);
        }

        [TestMethod]
        public void Whitelists()
        {
            // Arrange

            var archive = Archive.Get();
            var image = Image.Get();
            var list = new FileTypeList() { Groups = new[] { archive, image } };
            var validator = new FileTypeValidator(list, ValidationMode.Whitelist);

            // Act

            var acceptedExtensionsResult = validator.Validate(Python.GetFileTypes().SelectMany(ft => ft.Extension.FileExtensions));
            var blockedExtensionsResultA = validator.Validate(Archive.GetFileTypes().SelectMany(ft => ft.Extension.FileExtensions));
            var blockedExtensionsResultB = validator.Validate(Image.GetFileTypes().SelectMany(ft => ft.Extension.FileExtensions));


            // Assert

            Assert.IsFalse(acceptedExtensionsResult.IsSuccess);
            Assert.IsTrue(blockedExtensionsResultA.IsSuccess);
            Assert.IsTrue(blockedExtensionsResultB.IsSuccess);
        }

        [TestMethod]
        public void Analyses()
        {
            // Arrange

            const string TestExtension = "testextesnion";

            var type = new FileType()
            {
                Extension = TestExtension
            };
            var group = new FileTypeGroup()
            {
                FileTypes = new[] { type }
            };

            // Act

            var analyzer = new FileTypeAnalyzer(new FileTypeList() { Groups = new[] { group } });
            var detailA = analyzer.Analyze("test." + TestExtension);
            var detailB = analyzer.Analyze("text.nonExisting");

            // Assert
            Assert.AreEqual(group, detailA.MatchingGroups.First());
            Assert.AreEqual(type, detailA.MatchingFileTypes.First());
            Assert.IsTrue(detailB.IsEmpty);
        }

        [TestMethod]
        public void ConstructsHistogram()
        {
            // Arrange

            var list = new FileTypeList() { Groups = new[] { Audio.Get(), Image.Get() } };
            var extensions = new[] {
                Audio.GetFileTypes().FirstOrDefault(),
                Audio.GetFileTypes().Skip(1).FirstOrDefault(),
                Image.GetFileTypes().FirstOrDefault(),
                Image.GetFileTypes().FirstOrDefault(),
                Image.GetFileTypes().FirstOrDefault(),
                Image.GetFileTypes().FirstOrDefault()
            };
            var notDefinedFileNames = new[] { "unknown01", "unknown02" };

            // Act

            var histogram = FileTypeHistogram.Generate(
                list
                , extensions
                    .SelectMany(e => e.Extension.FileExtensions)
                    .Concat(notDefinedFileNames)
                    .Select(e => "test." + e));

            // Assert

            Assert.AreEqual(8, histogram.ItemsCount);
            Assert.AreEqual(5, histogram.Frequency.Count);
            Assert.AreEqual(1, histogram.Frequency.Values.Select(value => value.Frequency).Sum());
            Assert.AreEqual(0.5d, histogram.Frequency[Image.GetFileTypes().FirstOrDefault().Extension.Value].Frequency);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVsFileTypes.Contracts.Collections;
using MVsFileTypes.Predefined.Lists;
using System.Collections.Generic;
using System.Linq;

namespace MVsFileTypes.UnitTests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void FiltersList()
        {
            // Arrange

            var list = PredefinedFileTypes.Get();
            var toRemove = list
                .Groups
                .Take(3)
                .Select(g => g.FileTypes.First().Extension.FileExtensions.First())
                .ToArray();

            // Act

            var newList = list.Filter(toRemove, FilterOptions.None);

            // Assert

            Assert.AreEqual(toRemove.Length, newList.Groups.Count());
        }

        [TestMethod]
        [DataRow(FilterOptions.ThrowOnNotFoundItems, true)]
        [DataRow(FilterOptions.None, false)]
        public void ThrowsOnNotFoundInFiltering(FilterOptions option, bool shouldThrow)
        {
            // Arrange

            var list = PredefinedFileTypes.Get();
            var filter = list
                .Groups
                .Take(3)
                .Select(g => g.FileTypes.First().Extension.FileExtensions.First())
                .Concat(new[] { "nonExistingExtension" })
                .ToArray();

            // Act

            void action() => list.Filter(filter, option);

            // Assert

            if (shouldThrow)
                Assert.ThrowsException<KeyNotFoundException>(action);
            else
                action();
        }
    }
}

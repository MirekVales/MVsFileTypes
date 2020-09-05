using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVsFileTypes.Contracts.Collections;
using MVsFileTypes.Predefined.Lists;
using System.Collections.Generic;
using System.Linq;

namespace MVsFileTypes.UnitTests
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        [DataRow(FilterOptions.ThrowOnNotFoundItems, true)]
        [DataRow(FilterOptions.None, false)]
        public void ThrowsOnNotFoundInFiltering(FilterOptions option, bool shouldThrow)
        {
            // Arrange

            var group = PredefinedFileTypes.GetGroups().First();

            // Act

            void action() => group.Filter(new[] { "nonExistingExtension" }, option);

            // Assert

            if (shouldThrow)
                Assert.ThrowsException<KeyNotFoundException>(action);
            else
                action();
        }
    }
}

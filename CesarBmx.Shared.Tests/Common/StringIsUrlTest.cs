using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.Shared.Common.Extensions;

namespace CesarBmx.Shared.Tests.Common
{
    [TestClass]
    public class IsUrlTest
    {
        [TestMethod]
        public void Test_ReturnTrueForValidUrl()
        {
            //Arrange
            const string url = "https://wwww.google.ca";

            //Act
            var isUrl = url.IsUrl();

            //Assert
            Assert.IsTrue(isUrl);
        }

        [TestMethod]
        public void Test_ReturnFalseForInvalidValidUrl()
        {
            //Arrange
            const string url = "htt://wwww.google.ca";

            //Act
            var isUrl = url.IsUrl();

            //Assert
            Assert.IsFalse(isUrl);
        }
    }
}

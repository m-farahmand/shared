using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.Common.Extensions;

namespace CesarBmx.Tests.Common
{
    [TestClass]
    public class StringAsUrlTest
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

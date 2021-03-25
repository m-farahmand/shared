using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.Shared.Common.Extensions;

namespace CesarBmx.Shared.Tests.Common.Extensions
{
    [TestClass]
    public class StringExtensionTests
    {
        #region IsUrl

        [TestMethod]
        public void Test_IsUrl_ValidUrl()
        {
            //Arrange
            const string url = "https://wwww.google.ca";

            //Act
            var isUrl = url.IsUrl();

            //Assert
            Assert.IsTrue(isUrl);
        }

        [TestMethod]
        public void Test_IsUrl_InvalidValidUrl()
        {
            //Arrange
            const string url = "htt://wwww.google.ca";

            //Act
            var isUrl = url.IsUrl();

            //Assert
            Assert.IsFalse(isUrl);
        }

        #endregion

        #region ToReadable

        [TestMethod]
        public void Test_ToReadable_OneWord()
        {
            //Arrange
            var modelName = "User";

            //Act
            modelName = modelName.ToReadable();

            //Assert
            Assert.AreEqual("user", modelName);
        }

        [TestMethod]
        public void Test_ToReadable_TwoWords()
        {
            //Arrange
            var modelName = "UserRole";

            //Act
            modelName = modelName.ToReadable();

            //Assert
            Assert.AreEqual("user role", modelName);
        }
        [TestMethod]
        public void Test_ToReadable_ThreeWords()
        {
            //Arrange
            var modelName = "UserRoleWhatever";

            //Act
            modelName = modelName.ToReadable();

            //Assert
            Assert.AreEqual("user role whatever", modelName);
        }

        #endregion
    }
}

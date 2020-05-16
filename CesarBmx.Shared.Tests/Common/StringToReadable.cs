using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.Shared.Common.Extensions;

namespace CesarBmx.Shared.Tests.Common
{
    [TestClass]
    public class StringToReadable
    {
        [TestMethod]
        public void Test_OneWord()
        {
            //Arrange
            var modelName = "User";

            //Act
            modelName = modelName.ToReadable();

            //Assert
            Assert.AreEqual("user", modelName);
        }

        [TestMethod]
        public void Test_TwoWords()
        {
            //Arrange
            var modelName = "UserRole";

            //Act
            modelName = modelName.ToReadable();

            //Assert
            Assert.AreEqual("user role", modelName);
        }
        [TestMethod]
        public void Test_ThreeWords()
        {
            //Arrange
            var modelName = "UserRoleWhatever";

            //Act
            modelName = modelName.ToReadable();

            //Assert
            Assert.AreEqual("user role whatever", modelName);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.Shared.Common.Extensions;

namespace CesarBmx.Shared.Tests.Common
{
    [TestClass]
    public class NormalizeDecimal
    {
        [TestMethod]
        public void Test_Normalize()
        {
            //Arrange
            const decimal value = 55939.1521195100000m ;

            //Act
            var normalizeDecimal = value.Normalize();

            //Assert
            Assert.AreEqual(55939.15211951m, normalizeDecimal);
        }
    }
}

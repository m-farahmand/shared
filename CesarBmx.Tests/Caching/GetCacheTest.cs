using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CesarBmx.Caching.Extensions;

namespace CesarBmx.Tests.Caching
{
    [TestClass]
    public class GetCacheTest
    {
        [TestMethod]
        public void Test_WithNamespace()
        {
            //Arrange
            var mockedDistributedCache = new Mock<IDistributedCache>();
            var task = new Task<string>(()=> "Test");


            //Act
            var cachedObject = mockedDistributedCache.Object.GetCache("GetCache", task,10, GetType(), "Param1", "Param2");

            //Assert
            Assert.IsNull(cachedObject.Result);
        }


    }
}

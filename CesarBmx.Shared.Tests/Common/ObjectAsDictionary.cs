using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.Shared.Common.Extensions;

namespace CesarBmx.Shared.Tests.Common
{
    [TestClass]
    public class ObjectAsDictionary
    {
        private enum MyEnum
        {
            Value1
        }

        [TestMethod]
        public void Test_Object()
        {
            //Arrange
            var obj = new { ObjectId = 1, ObjectName = "MyObject" };

            //Act
            var dictionary = obj.AsDictionary();

            //Assert
            Assert.IsTrue(dictionary.Count == 2);
            Assert.AreEqual(1, dictionary["ObjectId"]);
            Assert.AreEqual("MyObject", dictionary["ObjectName"]);
        }
        [TestMethod]
        public void Test_Array()
        {
            //Arrange
            var obj = new { ObjectId = 1, ObjectName = new[] { "A", "B" } };

            //Act
            var dictionary = obj.AsDictionary();

            //Assert
            Assert.IsTrue(dictionary.Count == 2);
            Assert.AreEqual(1, dictionary["ObjectId"]);
            Assert.AreEqual("[A,B]", dictionary["ObjectName"]);
        }
        [TestMethod]
        public void Test_SubClass()
        {
            //Arrange
            var subClass = new { SubClassId = 2, SubClassName = "MySubClass" };
            var obj = new { ObjectId = 1, ObjectName = "MyObject", SubClass = subClass };

            //Act
            var dictionary = obj.AsDictionary();

            //Assert
            Assert.IsTrue(dictionary.Count == 3);
            Assert.AreEqual(1, dictionary["ObjectId"]);
            Assert.AreEqual("MyObject", dictionary["ObjectName"]);
            Assert.IsTrue(dictionary["SubClass"] is Dictionary<string, object>);
            Assert.AreEqual(2, ((Dictionary<string, object>)dictionary["SubClass"])["SubClassId"]);
            Assert.AreEqual("MySubClass", ((Dictionary<string, object>)dictionary["SubClass"])["SubClassName"]);
        }
        [TestMethod]
        public void Test_CustomEnum()
        {
            //Arrange
            var subClass = new { SubClassId = 2, SubClassName = "MySubClass" };
            var obj = new { ObjectId = 1, ObjectName = MyEnum.Value1, SubClass = subClass };

            //Act
            var dictionary = obj.AsDictionary();

            //Assert
            Assert.IsTrue(dictionary.Count == 3);
            Assert.AreEqual(1, dictionary["ObjectId"]);
            Assert.AreEqual(MyEnum.Value1, dictionary["ObjectName"]);
            Assert.IsTrue(dictionary["SubClass"] is Dictionary<string, object>);
            Assert.AreEqual(2, ((Dictionary<string, object>)dictionary["SubClass"])["SubClassId"]);
            Assert.AreEqual("MySubClass", ((Dictionary<string, object>)dictionary["SubClass"])["SubClassName"]);
        }
    }
}

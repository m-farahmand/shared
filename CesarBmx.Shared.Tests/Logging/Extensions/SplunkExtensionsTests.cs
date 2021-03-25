using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.Shared.Logging.Extensions;

namespace CesarBmx.Shared.Tests.Logging.Extensions
{
    [TestClass]
    public class SplunkExtensionsTests
    {
        [TestMethod]
        public void Test_AsSplunkKeyValueString_Object()
        {
            //Arrange
            var dictionary = new Dictionary<string, object>
            {
                {"ObjectId", "1"},
                {"ObjectName", "MyObject"}
            };

            //Act
            var str = dictionary.AsSplunkKeyValueString();

            //Assert
            Assert.AreEqual("ObjectId=1, ObjectName=MyObject", str);
        }
        [TestMethod]
        public void Test_AsSplunkKeyValueString_NullSubClass()
        {
            //Arrange
            var dictionary = new Dictionary<string, object>
            {
                {"ObjectId", "1"},
                {"SubClass",  null}
            };

            //Act
            var str = dictionary.AsSplunkKeyValueString();

            //Assert
            Assert.AreEqual("ObjectId=1, SubClass=null", str);
        }
        [TestMethod]
        public void Test_AsSplunkKeyValueString_Date()
        {
            //Arrange
            var dictionary = new Dictionary<string, object>
            {
                {"ObjectId", "1"},
                {"SubClass",  DateTime.MinValue}
            };

            //Act
            var str = dictionary.AsSplunkKeyValueString();

            //Assert
            Assert.AreEqual($"ObjectId=1, SubClass=\"{DateTime.MinValue}\"", str);
        }
        [TestMethod]
        public void Test_AsSplunkKeyValueString_Spaces()
        {
            //Arrange
            var dictionary = new Dictionary<string, object>
            {
                {"ObjectId", "1"},
                {"ObjectName", "MyObject"},
                {"ObjectDescription", "Blah blah blah blah blah blah blah "} // Only 30 characters will show
            };

            //Act
            var str = dictionary.AsSplunkKeyValueString();

            //Assert
            Assert.AreEqual("ObjectId=1, ObjectName=MyObject, ObjectDescription=\"Blah blah blah blah blah blah  {...}\"", str);
        }
        [TestMethod]
        public void Test_AsSplunkKeyValueString_SubDirectory()
        {
            //Arrange
            var dictionary = new Dictionary<string, object>
            {
                {"ObjectId", "1"},
                {"ObjectName", "MyObject"},
                {"SubClass", new Dictionary<string, object>
                {
                    {"SubClassId", 2},{"SubClassName", "MySubClass"}
                }}
            };

            //Act
            var str = dictionary.AsSplunkKeyValueString();

            //Assert
            Assert.AreEqual("ObjectId=1, ObjectName=MyObject, SubClass_SubClassId=2, SubClass_SubClassName=MySubClass", str);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.Logging.Extensions;

namespace CesarBmx.Tests.Logging
{
    [TestClass]
    public class DictionaryAsSplunkKeyValueStringTest
    {
        [TestMethod]
        public void Test()
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
        public void Test_WithNull()
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
        public void Test_WithDate()
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
        public void Test_WithJobFailed()
        {
            //Arrange
            var dictionary = new Dictionary<string, object>
            {
                {"JobFailed", "Exception message with spaces"}
            };

            //Act
            var str = dictionary.AsSplunkKeyValueString();

            //Assert
            Assert.AreEqual("JobFailed=\"Exception message with spaces\"", str);
        }
        [TestMethod]
        public void Test_WithSpaces()
        {
            //Arrange
            var dictionary = new Dictionary<string, object>
            {
                {"ObjectId", "1"},
                {"ObjectName", "MyObject"},
                {"ObjectDescription", "Blah blah blah"}
            };

            //Act
            var str = dictionary.AsSplunkKeyValueString();

            //Assert
            Assert.AreEqual("ObjectId=1, ObjectName=MyObject, ObjectDescription=\"{...}\"", str);
        }
        [TestMethod]
        public void Test_WithSubDirectory()
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

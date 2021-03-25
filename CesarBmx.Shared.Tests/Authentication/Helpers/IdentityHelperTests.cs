using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CesarBmx.Shared.Authentication.Attributes;
using CesarBmx.Shared.Authentication.Helpers;

namespace CesarBmx.Shared.Tests.Authentication.Helpers
{
    [TestClass]
    public class IdentityHelperTests
    {

        public class User
        {
            [Identity] public string UserId { get; set; }
            [Identity(ClaimTypes.Name)] public string Name { get; set; }
        }
        [TestMethod]
        public void Test_SetIdentityValues()
        {
            //Arrange
            var user = new User();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,"cesarc"),
                new Claim(ClaimTypes.Name,"Cesar Cañas")
            };


            //Act
            IdentityHelper.SetIdentityValues(ref user, claims);

            //Assert
            Assert.AreEqual("cesarc", user.UserId);
            Assert.AreEqual("Cesar Cañas", user.Name);
        }


    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using CesarBmx.Shared.Tests.Health.FakeModels;


namespace CesarBmx.Shared.Tests.Health
{
    /// <summary>
    /// Check SSL Cert Expire date.
    /// </summary>
    /// <notes>https://www.stevefenton.co.uk/2020/04/check-certificate-expiry-date-in-net-core/</notes>
    /// <returns></returns>
    [TestClass]
    public class SslCertificate
    {
        [TestMethod]
        public void Test_MissingCertificate()
        {
            //Arrange
            var sslCertificate = FakeSslCertificate.MissingCertificate();

            //Assert
            Assert.AreEqual(HealthStatus.Unhealthy, sslCertificate.HealthCheckResult.Status);
            Assert.AreEqual($"SSL certificate is missing on {sslCertificate.Url}", sslCertificate.HealthCheckResult.Description);
        }

        [TestMethod]
        public void Test_ExpiredCertificate()
        {
            //Arrange
            var sslCertificate = FakeSslCertificate.ExpiredCertificate();

            //Assert
            Assert.AreEqual(HealthStatus.Unhealthy, sslCertificate.HealthCheckResult.Status);
            Assert.AreEqual("SSL certificate expired 2 days ago", sslCertificate.HealthCheckResult.Description);
        }

        [TestMethod]
        public void Test_AboutToExpireCertificate()
        {
            //Arrange
            var sslCertificate = FakeSslCertificate.AboutToExpireCertificate();

            //Assert
            Assert.AreEqual(HealthStatus.Degraded, sslCertificate.HealthCheckResult.Status);
            Assert.AreEqual("SSL certificate is about to expire in 2 days", sslCertificate.HealthCheckResult.Description);
        }

        [TestMethod]
        public void Test_NotValidYetCertificate()
        {
            //Arrange
            var sslCertificate = FakeSslCertificate.NotValidYetCertificate();

            //Assert
            Assert.AreEqual(HealthStatus.Unhealthy, sslCertificate.HealthCheckResult.Status);
            Assert.AreEqual("SSL certificate will become valid in 2 days", sslCertificate.HealthCheckResult.Description);
        }

        [TestMethod]
        public void Test_CertificateVersionIsNotGreaterThanTwo()
        {
            //Arrange
            var sslCertificate = FakeSslCertificate.V2Certificate();

            //Assert
            Assert.AreEqual(HealthStatus.Degraded, sslCertificate.HealthCheckResult.Status);
            Assert.AreEqual("SSL certificate is lower than version 2", sslCertificate.HealthCheckResult.Description);
        }

        [TestMethod]
        public void Test_CertificatetHasNoSubject()
        {
            //Arrange
            var sslCertificate = FakeSslCertificate.NoSubjectCertificate();

            //Assert
            Assert.AreEqual(HealthStatus.Degraded, sslCertificate.HealthCheckResult.Status);
            Assert.AreEqual("SSL certificate has no subject", sslCertificate.HealthCheckResult.Description);
        }

        [TestMethod]
        public void Test_CertificateHasNoIssuer()
        {
            //Arrange
            var sslCertificate = FakeSslCertificate.NoIssuerCertificate();

            //Assert
            Assert.AreEqual(HealthStatus.Degraded, sslCertificate.HealthCheckResult.Status);
            Assert.AreEqual("SSL certificate has no issuer", sslCertificate.HealthCheckResult.Description);
        }

    }
}

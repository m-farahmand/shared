using System;
using CesarBmx.Health.Models;

namespace CesarBmx.Tests.Health.FakeData
{
   public static class FakeSslCertificate
   {
       public static SslCertificate ValidCertificate()
       {
           return new SslCertificate
           {
               HasCertificate = true,
               NotAfter = DateTime.UtcNow.AddMonths(6),
               NotBefore = DateTime.UtcNow.AddMonths(-1),
               Version = 3,
               Subject = "CN=*.pinnacle.com, OU=Domain Control Validated",
               Issuer = "CN=Go Daddy Secure Certificate Authority - G2, OU=http://certs.godaddy.com/repository/, O=\"GoDaddy.com, Inc.\", L=Scottsdale, S=Arizona, C=US"
        };
       }
       public static SslCertificate MissingCertificate()
       {
           var certificate = ValidCertificate();
           certificate.HasCertificate = false;
           return certificate;
       }
        public static SslCertificate ExpiredCertificate()
       {
           var certificate = ValidCertificate();
           certificate.NotAfter = DateTime.UtcNow.AddDays(-2);
           return certificate;
       }
       public static SslCertificate AboutToExpireCertificate()
       {
           var certificate = ValidCertificate();
           certificate.NotAfter = DateTime.UtcNow.AddDays(2);
           return certificate;
       }
        public static SslCertificate NotValidYetCertificate()
        {
            var certificate = ValidCertificate();
            certificate.NotBefore = DateTime.UtcNow.AddDays(2);
            return certificate;
        }
        public static SslCertificate NoSubjectCertificate()
        {
            var certificate = ValidCertificate();
            certificate.Subject = string.Empty;
            return certificate;
        }
        public static SslCertificate NoIssuerCertificate()
        {
            var certificate = ValidCertificate();
            certificate.Issuer = string.Empty;
            return certificate;
        }
        public static SslCertificate V2Certificate()
        {
            var certificate = ValidCertificate();
            certificate.Version = 2;
            return certificate;
        }
    }
}


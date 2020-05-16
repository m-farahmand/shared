using System;

namespace CesarBmx.Shared.Tests.Health.FakeModels
{
   public static class FakeSslCertificate
   {
       public static Shared.Health.Models.SslCertificate ValidCertificate()
       {
           return new Shared.Health.Models.SslCertificate
           {
               HasCertificate = true,
               NotAfter = DateTime.UtcNow.AddMonths(6),
               NotBefore = DateTime.UtcNow.AddMonths(-1),
               Version = 3,
               Subject = "CN=*.pinnacle.com, OU=Domain Control Validated",
               Issuer = "CN=Go Daddy Secure Certificate Authority - G2, OU=http://certs.godaddy.com/repository/, O=\"GoDaddy.com, Inc.\", L=Scottsdale, S=Arizona, C=US"
        };
       }
       public static Shared.Health.Models.SslCertificate MissingCertificate()
       {
           var certificate = ValidCertificate();
           certificate.HasCertificate = false;
           return certificate;
       }
        public static Shared.Health.Models.SslCertificate ExpiredCertificate()
       {
           var certificate = ValidCertificate();
           certificate.NotAfter = DateTime.UtcNow.AddDays(-2);
           return certificate;
       }
       public static Shared.Health.Models.SslCertificate AboutToExpireCertificate()
       {
           var certificate = ValidCertificate();
           certificate.NotAfter = DateTime.UtcNow.AddDays(2);
           return certificate;
       }
        public static Shared.Health.Models.SslCertificate NotValidYetCertificate()
        {
            var certificate = ValidCertificate();
            certificate.NotBefore = DateTime.UtcNow.AddDays(2);
            return certificate;
        }
        public static Shared.Health.Models.SslCertificate NoSubjectCertificate()
        {
            var certificate = ValidCertificate();
            certificate.Subject = string.Empty;
            return certificate;
        }
        public static Shared.Health.Models.SslCertificate NoIssuerCertificate()
        {
            var certificate = ValidCertificate();
            certificate.Issuer = string.Empty;
            return certificate;
        }
        public static Shared.Health.Models.SslCertificate V2Certificate()
        {
            var certificate = ValidCertificate();
            certificate.Version = 2;
            return certificate;
        }
    }
}


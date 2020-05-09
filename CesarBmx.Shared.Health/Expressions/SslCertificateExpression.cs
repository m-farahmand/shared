using System;
using System.Linq.Expressions;
using CesarBmx.Shared.Health.Models;

namespace CesarBmx.Shared.Health.Expressions
{
    public static class SslCertificateExpression
    {
        public static Expression<Func<SslCertificate, bool>> CertificateMissing()
        {
            return x => !x.HasCertificate;
        }
        public static Expression<Func<SslCertificate, bool>> CertificateAboutToExpire(int daysToExpire)
        {
            return x => x.NotAfter.Date < DateTime.UtcNow.AddDays(daysToExpire).Date;
        }
        public static Expression<Func<SslCertificate, bool>> CertificateAlreadyExpired()
        {
            return x => x.NotAfter.Date <= DateTime.UtcNow.Date;
        }
        public static Expression<Func<SslCertificate, bool>> CertificateIsNotValidYet()
        {
            return x => x.NotBefore.Date > DateTime.UtcNow.Date;
        }
        public static Expression<Func<SslCertificate, bool>> CertificateHasNoIssuer()
        {
            return x => string.IsNullOrEmpty(x.Issuer);
        }
        public static Expression<Func<SslCertificate, bool>> CertificateHasNoSubject()
        {
            return x => string.IsNullOrEmpty(x.Subject);
        }
        public static Expression<Func<SslCertificate, bool>> CertificateDoesNotHaveVersionGreaterThan2()
        {
            return x => x.Version < 3;
        }
    }
}

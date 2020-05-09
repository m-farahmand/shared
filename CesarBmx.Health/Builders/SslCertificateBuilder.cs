using System;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using CesarBmx.Health.Expressions;
using CesarBmx.Health.Models;

namespace CesarBmx.Health.Builders
{
    public static class SslCertificateBuilder 
    {
        public static HealthCheckResult BuildResult(SslCertificate sslCertificate)
        {
            // The order matters

            // Certificate already expired 
            if (SslCertificateExpression.CertificateMissing().Compile().Invoke(sslCertificate))
            {
                return HealthCheckResult.Unhealthy($"SSL certificate is missing on {sslCertificate.Url}");
            }

            // Certificate already expired 
            if (SslCertificateExpression.CertificateAlreadyExpired().Compile().Invoke(sslCertificate))
            {
                var daysExpired = (DateTime.UtcNow.Date - sslCertificate.NotAfter.Date).Days;
                return HealthCheckResult.Unhealthy($"SSL certificate expired {daysExpired} days ago");
            }

            // Certificate has not become valid yet
            if (SslCertificateExpression.CertificateIsNotValidYet().Compile().Invoke(sslCertificate))
            {
                var daysToBecomeValid = (sslCertificate.NotBefore.Date - DateTime.UtcNow.Date).Days;
                return HealthCheckResult.Unhealthy($"SSL certificate will become valid in {daysToBecomeValid} days");
            }

            // Certificate about to expire in less than 60 days
            if (SslCertificateExpression.CertificateAboutToExpire(60).Compile().Invoke(sslCertificate))
            {
                var daysToExpire = (sslCertificate.NotAfter.Date - DateTime.UtcNow.Date).Days;
                return HealthCheckResult.Degraded($"SSL certificate is about to expire in {daysToExpire} days");
            }

            // Certificate has no issuer
            if (SslCertificateExpression.CertificateHasNoIssuer().Compile().Invoke(sslCertificate))
            {
                return HealthCheckResult.Degraded("SSL certificate has no issuer");
            }

            // Certificate has no subject
            if (SslCertificateExpression.CertificateHasNoSubject().Compile().Invoke(sslCertificate))
            {
                return HealthCheckResult.Degraded("SSL certificate has no subject");
            }

            // Certificate is no greater than v2
            if (SslCertificateExpression.CertificateDoesNotHaveVersionGreaterThan2().Compile().Invoke(sslCertificate))
            {
                return HealthCheckResult.Degraded("SSL certificate is lower than version 2");
            }

            // Return
            return HealthCheckResult.Healthy(sslCertificate.Url);
        }
    }
}
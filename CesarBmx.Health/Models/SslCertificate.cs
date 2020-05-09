using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using CesarBmx.Health.Builders;


namespace CesarBmx.Health.Models
{
    /// <summary>
    /// Get SSL information of the running host
    /// </summary>
    public class SslCertificate
    {
        /// <summary>
        /// Gets url where the cert lives
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets whether the site has certificate or not
        /// </summary>
        public bool HasCertificate { get; set; }

        /// <summary>
        /// Gets the date in local time after which a certificate is no longer valid.
        /// </summary>
        public DateTime NotAfter { get; set; }

        /// <summary>
        /// Gets the date in local time on which a certificate becomes valid.
        /// </summary>
        public DateTime NotBefore { get; set; }

        /// <summary>
        /// Gets the X.509 format version of a certificate.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Gets the subject distinguished name from a certificate.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets the distinguished name of the certificate issuer.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets if the certificate is valid
        /// </summary>
        public HealthCheckResult HealthCheckResult => SslCertificateBuilder.BuildResult(this);

        /// <summary>
        /// Get SSL Cert info
        /// </summary>
        /// <param name="url">Host url</param>
        /// <returns></returns>
        public async Task GetServerCertificationInfo(string url)
        {
            Url = url;

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (request, cert, chain, policyErrors) =>
                {
                    NotAfter = cert.NotAfter;
                    NotBefore = cert.NotBefore;
                    Version = cert.Version;
                    Subject = cert.Subject;
                    Issuer = cert.Issuer;
                    HasCertificate = true;

                    return true;
                }
            };

            var httpClient = new HttpClient(httpClientHandler);
            await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
        }

    }
}

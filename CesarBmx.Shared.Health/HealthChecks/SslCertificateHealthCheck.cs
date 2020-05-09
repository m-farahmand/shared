using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using CesarBmx.Shared.Health.Models;

namespace CesarBmx.Shared.Health.HealthChecks
{
    public class SslCertificateHealthCheck : IHealthCheck
    {

        private readonly IConfiguration _configuration;

        public SslCertificateHealthCheck(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            // Instantiate certificate
            var sslCertificationCheck = new SslCertificate();

            // Get url (e.g. "https://dev.pinnacle.com")
            var url = _configuration["Health:SslCertificateHealthCheck"];

            // Get info
            await sslCertificationCheck.GetServerCertificationInfo(url);

            // Return result
            return sslCertificationCheck.HealthCheckResult;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CesarBmx.Health.HealthChecks
{
    public class SslCertificateBuilder : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            await Task.Delay(1, cancellationToken);

            return HealthCheckResult.Healthy();
            //return HealthCheckResult.Degraded("Explain why");
            //return HealthCheckResult.Unhealthy("Explain why");
        }
    }
}
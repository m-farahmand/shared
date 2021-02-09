


namespace CesarBmx.Shared.Application.Settings
{
    public  class AuthenticationSettings
    {
        public string AuthenticationType { get; set; }
        public bool Enabled { get; set; }
        public string ApiKey { get; set; }
        public string Secret { get; set; }
        public string Issuer { get; set; }
    }
}

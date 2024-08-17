namespace RedisIntegration.API
{
    public class RedisSettings
    {
        public string[] Endpoints { get; set; }
        public int LinearRetryMilliseconds { get; set; }
        public int DefaultExpiryInMinutes { get; set; }
        public string Password { get; set; }
    }
}

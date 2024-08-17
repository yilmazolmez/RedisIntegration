using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisIntegration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedisIntegrationController : ControllerBase
    {

        private readonly IDatabase _redisDatabase;

        public RedisIntegrationController(IConnectionMultiplexer redis)
        {
            _redisDatabase = redis.GetDatabase();
        }

        [HttpGet("setValue")]
        public async Task<IActionResult> SetValue(string key, string value)
        {
            await _redisDatabase.StringSetAsync(key, value, TimeSpan.FromMinutes(1));

            return Ok("Value set successfully");
        }

        [HttpGet("getValue")]
        public async Task<IActionResult> GetValue(string key)
        {
            var value = await _redisDatabase.StringGetAsync(key);

            if (value.IsNullOrEmpty)
            {
                return NotFound("Value not found");
            }

            return Ok(value.ToString());
        }


        [HttpGet("setGroupValue")]
        public async Task<IActionResult> SetGroupValue(string key, string value)
        {
            key = $"Group1:{key}";
            await _redisDatabase.StringSetAsync(key, value, TimeSpan.FromMinutes(1));

            return Ok("Value set successfully");
        }
    }
}

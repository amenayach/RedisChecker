namespace RedisChecker
{
    using StackExchange.Redis;
    using System;

    public class RedisService
    {
        private readonly string connectionString;

        public RedisService(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public void Test()
        {
            using (var redis = ConnectionMultiplexer.Connect(connectionString?.Trim()))
            {
                var database = redis.GetDatabase();

                database.StringSet("test", "Test from Redis checker");

                Console.WriteLine("Reading the \"test\" key...");
                Console.WriteLine(database.StringGet("test"));
                Console.WriteLine("Done!");
            }
        }
    }
}

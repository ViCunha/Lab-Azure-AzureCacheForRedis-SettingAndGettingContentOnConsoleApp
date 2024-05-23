using StackExchange.Redis;

// connection string to your Redis Cache    
string connectionString = "";

const string KEY = "test:key";

Console.WriteLine(">> Begin");

using (var cache = ConnectionMultiplexer.Connect(connectionString) )
{
    IDatabase db = cache.GetDatabase();

     // Snippet below executes a PING to test the server connection
     var result = await db.ExecuteAsync("ping");
     Console.WriteLine(result.ToString());

     // Call StringSetAsync on the IDatabase object to set the key "test:key" to the value "100"
     bool setValue = await db.StringSetAsync(KEY, "100");
     Console.WriteLine($"SET: {setValue}");

    string getValue = await db.StringGetAsync(KEY); 
    Console.WriteLine($"GET: {getValue}");
}

Console.WriteLine(">> End");
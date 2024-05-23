### Overview
---
In this exercise you learn how to:

- Create a new Redis Cache instance by using Azure CLI commands.

- Create a .NET Core console app to add and retrieve values from the cache by using the StackExchange.Redis package.
   
### Key Aspects
---
- Azure Portal

- Azure Could Shell

- Azure CLI

- Visual Studio Code

- Azure Cache For Redis


### Environment
---
Microsoft Azure Portal

- Valid Subscription

Visual Studio Code

- C# extension

- Dotnet 8.0 or greater


### Actions
---
Connect to Azure
- Sign in to the Azure portal
- Open the Azure Cloud Shell using the Bash

Prepare your environment
- Set environment variables
```
DEFAULT_CURRENTDATETIME="20240523225000"
DEFAULT_LOCATION="eastus2"
DEFAULT_RESOURCEGROUP_NAME="myresourcegroup${DEFAULT_CURRENTDATETIME}"
AZUREREDIS_NAME="REDIS${DEFAULT_CURRENTDATETIME}"
```

- Create a resource group
```
az group create --name ${DEFAULT_RESOURCEGROUP_NAME} --location ${DEFAULT_LOCATION}
```

Create an Azure Cache for Redis instance
- Create an Azure Cache for Redis instance
```
az redis create --resource-group ${DEFAULT_RESOURCEGROUP_NAME} --location ${DEFAULT_LOCATION} --name ${AZUREREDIS_NAME} --sku Basic --vm-size c0
```

- Select Access keys in the Settings section of the Navigation Pane
```
Xyz
```

Create a console app
- Create and access a project folder
```
md Lab-Azure-AzureCacheForRedis-SettingAndGettingContentOnConsoleApp
cd Lab-Azure-AzureCacheForRedis-SettingAndGettingContentOnConsoleApp
```

- Open Visual Studio Code using the project folder directory as the base
```
code .
```

- Open the terminal in Visual Studio Code

- Add the libraries to the console app
```
dotnet add package StackExchange.Redis;
```

- Define Program.cs
```
// connection string to your Redis Cache    
string connectionString = "REDIS_CONNECTION_STRING";

using (var cache = ConnectionMultiplexer.Connect(connectionString))
{
    IDatabase db = cache.GetDatabase();

    // Snippet below executes a PING to test the server connection
    var result = await db.ExecuteAsync("ping");
    Console.WriteLine($"PING = {result.Type} : {result}");

    // Call StringSetAsync on the IDatabase object to set the key "test:key" to the value "100"
    bool setValue = await db.StringSetAsync("test:key", "100");
    Console.WriteLine($"SET: {setValue}");

    // StringGetAsync retrieves the value for the "test" key
    string getValue = await db.StringGetAsync("test:key");
    Console.WriteLine($"GET: {getValue}");
}
```

- Compile the project
```
dotnet build
```

- Execute the program
```
dotnet run
```

Publish the code
- Create the repository Lab-Azure-AzureCacheForRedis-SettingAndGettingContentOnConsoleApp
- Generate a new specific/dedicated personal access token (Fine-grained tokens)
- Publish the code to GitHub
  
Clean up resources
- Delete the Resource Groups and its content
```
az group delete --name ${DEFAULT_RESOURCEGROUP} --no-wait
```

### Media
---
![image](https://github.com/ViCunha/Lab-Azure-AzureCacheForRedis-SettingAndGettingContentOnConsoleApp/assets/65992033/d17e9364-32ba-4d5f-b7e5-bdd2abd496c8)
---
![image](https://github.com/ViCunha/Lab-Azure-AzureCacheForRedis-SettingAndGettingContentOnConsoleApp/assets/65992033/cc427709-03e8-426f-a3ea-6b1120e13689)


### References
---
- [Exercise - Connect an app to Azure Cache for Redis by using .NET Core](https://learn.microsoft.com/en-us/training/modules/develop-for-azure-cache-for-redis/5-console-app-azure-cache-redis)

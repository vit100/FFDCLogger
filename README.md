# FFDCLogger - FFDC Console logger formatter.

This package registers extension method `AddFFDCJsonLogger()`, which in turn registers JsonFormatter suitable for FFDC.

# How to use?

1. Download package from https://www.nuget.org/packages/FFDCLogger using instructions provided on top of [this page](https://www.nuget.org/packages/FFDCLogger/).
2. In your projects main.cs add following
```
// --main.cs--
using FFDCLogger;
//....

 public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders(); // in FFDC we need special logger - with predefined output format
                    loggingBuilder.AddFFDCJsonLogger(); // call extension method to register formatter.
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
 //...
 ```



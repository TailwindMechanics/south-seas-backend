// Program.cs

using Supabase;
using Serilog;

using SouthSeas.Lifetime;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);
{
    // Configure web server
    var port = Environment.GetEnvironmentVariable("PORT");
    builder.WebHost.UseUrls($"http://*:{port}");
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Supabase service
    var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
    var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
    if (url != null)
    {
        var options = new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true,
        };

        builder.Services.AddSingleton(provider => new Client(url, key, options));
    }
    else throw new InvalidOperationException("Supabase environment variable not found.");

    // Logging
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(SouthSeas.Logs.Loggers.System());
    Log.Logger = SouthSeas.Logs.Loggers.Message();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    new Lifetime().Subscribe(app.Services);
    app.Run();
}

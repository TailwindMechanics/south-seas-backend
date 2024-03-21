//path: src\Logs\Loggers.cs

using Serilog.Core;
using Serilog;

namespace SouthSeas.Logs
{
    public static class Loggers
    {
        public static Logger System()
            => CreateLogger("system_logs", "SYSTEM_LOGGING_LEVEL");
        public static Logger Message()
            => CreateLogger("message_logs", "MESSAGE_LOGGING_LEVEL");

        static Logger CreateLogger(string category, string envarKey)
        {
            var level = Environment.GetEnvironmentVariable(envarKey);
            var serilogLevel = level switch
            {
                "Verbose" => Serilog.Events.LogEventLevel.Verbose,
                "Debug" => Serilog.Events.LogEventLevel.Debug,
                "Information" => Serilog.Events.LogEventLevel.Information,
                "Warning" => Serilog.Events.LogEventLevel.Warning,
                "Error" => Serilog.Events.LogEventLevel.Error,
                "Fatal" => Serilog.Events.LogEventLevel.Fatal,
                _ => Serilog.Events.LogEventLevel.Information,
            };

            Serilog.Debugging.SelfLog.Enable(Console.Error);

            return new LoggerConfiguration()
                .MinimumLevel.Is(serilogLevel)
                .Enrich.WithProperty("Category", category)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}

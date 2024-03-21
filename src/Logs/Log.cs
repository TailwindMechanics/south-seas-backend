//path: src\Logs\Log.cs

namespace SouthSeas.Logs
{
    public static class Log
    {
        private static string ThisProject => "SS Backend";

        public static void Online()
            => Serilog.Log.Information($"===> {ThisProject} Online <===");

        public static void Offline()
            => Serilog.Log.Information($"===> {ThisProject} Offline <===");

        public static void Info(string message)
            => Serilog.Log.Information($"{ThisProject} ==> {message}");

        public static void Warning(string message)
            => Serilog.Log.Warning($"{ThisProject} ==> {message}");
    }
}
//path: src\Lifetime\Lifetime.cs

using SouthSeas.Logs;

namespace SouthSeas
{
    public class Lifetime()
    {
        public void Subscribe(IServiceProvider serviceProvider, Action? onStarted = null, Action? onEnded = null)
        {
            var lifetime = serviceProvider.GetRequiredService<IHostApplicationLifetime>();
            lifetime.ApplicationStarted.Register(() =>
            {
                Log.Online();
                onStarted?.Invoke();
            });
            lifetime.ApplicationStopping.Register(() =>
            {
                Log.Offline();
                Serilog.Log.CloseAndFlush();
                onEnded?.Invoke();
            });
        }
    }
}

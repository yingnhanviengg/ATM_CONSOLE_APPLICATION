using ATM_CONSOLE_APPLICATION.View;
using Sentry;
using System.Text;

namespace ATM_CONSOLE_APPLICATION
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SentrySdk.Init(o =>
            {
                // Tells which project in Sentry to send events to:
                o.Dsn = "https://10b89f7d3f464402986bcfc84d91f98b@o4504731010990080.ingest.sentry.io/4504731017674752";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                o.TracesSampleRate = 1.0;
                // Enable Global Mode if running in a client app
                o.IsGlobalModeEnabled = true;
            }))
            {
                Console.Clear();
                Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;
                Console.Title = "ATM CONSOLE APPLICATION";
                MainMenu mainMenu = new MainMenu();
                mainMenu.ShowMainMenu();
            }            
        }
    }
}
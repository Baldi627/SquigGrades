using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;
using System.Threading.Tasks;
namespace SquigGrades
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Register toast activation handler
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // This runs on a background thread, so marshal to UI if needed
                var arguments = toastArgs.Argument;
                if (arguments.Contains("action=downloadUpdate"))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://github.com/Baldi627/SquigGrades/releases",
                        UseShellExecute = true
                    });
                }
                // "Ignore" does nothing, but you could log or handle as needed
            };
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
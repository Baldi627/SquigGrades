using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace SquigGrades
{
    internal class Notifier
    {

        public static void NotifyNormal(string message, string title)
        {
            ToastContentBuilder toastContent = new ToastContentBuilder()
                .AddText(title)
                .AddText(message);
            toastContent.Show();
        }
        public static void NotifyNewUpdate(string message, string title, string note)
        {
            ToastContentBuilder toastContent = new ToastContentBuilder()
                .AddText(title)
                .AddText(message)
                .AddAttributionText(note)
                .SetToastScenario(ToastScenario.Reminder)
                .AddAudio(new Uri("ms-winsoundevent:Notification.Reminder"))
                .AddButton(new ToastButton()
                    .SetContent("Download Update")
                    .AddArgument("action", "downloadUpdate")
                    .SetBackgroundActivation())
                .AddButton(new ToastButton()
                    .SetContent("Ignore")
                    .AddArgument("action", "ignoreUpdate")
                    .SetBackgroundActivation());
            toastContent.Show();
        }
    }
}

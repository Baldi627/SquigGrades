using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquigGrades
{
    using System.Text.Json;

    namespace SquigGrades
    {
        public class AppSettings
        {
            public bool AllowPrereleaseUpdates { get; set; } = false;

            private static readonly string SettingsFilePath =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SquigGrades", "settings.json");

            public static AppSettings Load()
            {
                try
                {
                    if (File.Exists(SettingsFilePath))
                    {
                        var json = File.ReadAllText(SettingsFilePath);
                        return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
                    }
                }
                catch { }
                return new AppSettings();
            }

            public void Save()
            {
                try
                {
                    var dir = Path.GetDirectoryName(SettingsFilePath);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir!);

                    var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(SettingsFilePath, json);
                }
                catch { }
            }
        }
    }
}

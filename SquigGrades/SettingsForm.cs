using Microsoft.VisualBasic;
using SquigGrades.SquigGrades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquigGrades
{
    public partial class SettingsForm : Form
    {
        private AppSettings appSettings = AppSettings.Load();
        private bool allowPrereleaseUpdates = false;
        public event EventHandler? ColorSettingsChanged;
        public SettingsForm()
        {
            InitializeComponent();
            allowPrereleaseUpdates = appSettings.AllowPrereleaseUpdates;
            allowPrereleaseCheckbox.Checked = allowPrereleaseUpdates;
            panelBackgroundPreview.BackColor = ColorTranslator.FromHtml(appSettings.BackgroundColor);
            panelForegroundPreview.BackColor = ColorTranslator.FromHtml(appSettings.ForegroundColor);
            toolTip1.SetToolTip(allowPrereleaseCheckbox, "Allow updates to pre-release versions of SquigGrades. This may include beta or alpha versions that are not fully tested.");
            toolTip1.SetToolTip(btnBGColor, "Click to change the background color of the application.");
            toolTip1.SetToolTip(btnFGColor, "Click to change the foreground color of the application.");
        }

        private void allowPrereleaseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            allowPrereleaseUpdates = allowPrereleaseCheckbox.Checked;
            appSettings.AllowPrereleaseUpdates = allowPrereleaseUpdates;
            appSettings.Save();
        }

        private void OnColorSettingsChanged()
        {
            ColorSettingsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnDefautSettings_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset all settings to default? This action cannot be undone.", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                appSettings.BackgroundColor = "#FFFFFF"; // Default: white
                appSettings.ForegroundColor = "#000000"; // Default: black
                appSettings.AllowPrereleaseUpdates = false; // Default: false
                panelBackgroundPreview.BackColor = ColorTranslator.FromHtml(appSettings.BackgroundColor);
                panelForegroundPreview.BackColor = ColorTranslator.FromHtml(appSettings.ForegroundColor);
                allowPrereleaseCheckbox.Checked = appSettings.AllowPrereleaseUpdates;
                appSettings.Save();
                MessageBox.Show("Settings have been reset to default.", "Reset Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBGColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = ColorTranslator.FromHtml(appSettings.BackgroundColor);
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                appSettings.BackgroundColor = ColorTranslator.ToHtml(colorDialog1.Color);
                panelBackgroundPreview.BackColor = colorDialog1.Color;
                appSettings.Save();
                OnColorSettingsChanged();
                Notifier.NotifyNormal("It is recommended that you restart SquigGrades to update the Background Color", $"Background Color Changed to {appSettings.BackgroundColor.ToString()}");
            }
        }

        private void btnFGColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = ColorTranslator.FromHtml(appSettings.ForegroundColor);
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                appSettings.ForegroundColor = ColorTranslator.ToHtml(colorDialog1.Color);
                panelForegroundPreview.BackColor = colorDialog1.Color;
                appSettings.Save();
                OnColorSettingsChanged();
                Notifier.NotifyNormal("It is recommended that you restart SquigGrades to update the Foreground Color", $"Foreground Color Changed to {appSettings.ForegroundColor.ToString()}");
            }
        }
    }
}

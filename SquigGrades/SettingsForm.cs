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
        public SettingsForm()
        {
            InitializeComponent();
            allowPrereleaseUpdates = appSettings.AllowPrereleaseUpdates;
            allowPrereleaseCheckbox.Checked = allowPrereleaseUpdates;
        }

        private void allowPrereleaseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            allowPrereleaseUpdates = allowPrereleaseCheckbox.Checked;
            appSettings.Save();
        }
    }
}

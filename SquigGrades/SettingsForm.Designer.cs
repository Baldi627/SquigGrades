namespace SquigGrades
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            allowPrereleaseCheckbox = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            btnFGColor = new Button();
            btnBGColor = new Button();
            panelBackgroundPreview = new Panel();
            panelForegroundPreview = new Panel();
            toolTip1 = new ToolTip(components);
            colorDialog1 = new ColorDialog();
            btnDefautSettings = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // allowPrereleaseCheckbox
            // 
            allowPrereleaseCheckbox.AutoSize = true;
            allowPrereleaseCheckbox.Location = new Point(8, 6);
            allowPrereleaseCheckbox.Name = "allowPrereleaseCheckbox";
            allowPrereleaseCheckbox.Size = new Size(147, 24);
            allowPrereleaseCheckbox.TabIndex = 0;
            allowPrereleaseCheckbox.Text = "Allow Prereleases";
            allowPrereleaseCheckbox.UseVisualStyleBackColor = true;
            allowPrereleaseCheckbox.CheckedChanged += allowPrereleaseCheckbox_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(372, 415);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(allowPrereleaseCheckbox);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(364, 382);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Update Settings";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnFGColor);
            tabPage2.Controls.Add(btnBGColor);
            tabPage2.Controls.Add(panelBackgroundPreview);
            tabPage2.Controls.Add(panelForegroundPreview);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(364, 382);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Other Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnFGColor
            // 
            btnFGColor.Location = new Point(8, 46);
            btnFGColor.Name = "btnFGColor";
            btnFGColor.Size = new Size(200, 29);
            btnFGColor.TabIndex = 6;
            btnFGColor.Text = "Foreground Color";
            btnFGColor.UseVisualStyleBackColor = true;
            btnFGColor.Click += btnFGColor_Click;
            // 
            // btnBGColor
            // 
            btnBGColor.Location = new Point(8, 11);
            btnBGColor.Name = "btnBGColor";
            btnBGColor.Size = new Size(200, 29);
            btnBGColor.TabIndex = 5;
            btnBGColor.Text = "Background Color";
            btnBGColor.UseVisualStyleBackColor = true;
            btnBGColor.Click += btnBGColor_Click;
            // 
            // panelBackgroundPreview
            // 
            panelBackgroundPreview.Location = new Point(214, 3);
            panelBackgroundPreview.Name = "panelBackgroundPreview";
            panelBackgroundPreview.Size = new Size(36, 37);
            panelBackgroundPreview.TabIndex = 3;
            // 
            // panelForegroundPreview
            // 
            panelForegroundPreview.Location = new Point(214, 46);
            panelForegroundPreview.Name = "panelForegroundPreview";
            panelForegroundPreview.Size = new Size(36, 40);
            panelForegroundPreview.TabIndex = 4;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // btnDefautSettings
            // 
            btnDefautSettings.Dock = DockStyle.Bottom;
            btnDefautSettings.Location = new Point(0, 421);
            btnDefautSettings.Name = "btnDefautSettings";
            btnDefautSettings.Size = new Size(372, 29);
            btnDefautSettings.TabIndex = 2;
            btnDefautSettings.Text = "Reset to Default Settings";
            btnDefautSettings.UseVisualStyleBackColor = true;
            btnDefautSettings.Click += btnDefautSettings_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 450);
            Controls.Add(btnDefautSettings);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            Text = "Settings";
            TopMost = true;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CheckBox allowPrereleaseCheckbox;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolTip toolTip1;
        private ColorDialog colorDialog1;
        private Panel panelBackgroundPreview;
        private Panel panelForegroundPreview;
        private Button btnBGColor;
        private Button btnFGColor;
        private Button btnDefautSettings;
    }
}
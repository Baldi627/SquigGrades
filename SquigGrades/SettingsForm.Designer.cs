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
            allowPrereleaseCheckbox = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label1 = new Label();
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
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(301, 450);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(allowPrereleaseCheckbox);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(293, 417);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Update Settings";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(293, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Other Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(264, 40);
            label1.TabIndex = 0;
            label1.Text = "No additional settings exist right now, \r\nplease try again at a later date!\r\n";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 450);
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
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox allowPrereleaseCheckbox;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
    }
}
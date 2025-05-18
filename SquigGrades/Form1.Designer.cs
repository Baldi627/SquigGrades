namespace SquigGrades
{
    partial class Form1
    {
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsMenu;
        private System.Windows.Forms.ToolStripMenuItem addStudentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAssignmentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnRemoveAssignment;





        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dgvGrades = new DataGridView();
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            loadMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            actionsMenu = new ToolStripMenuItem();
            addStudentMenuItem = new ToolStripMenuItem();
            addAssignmentMenuItem = new ToolStripMenuItem();
            btnRemoveAssignment = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvGrades).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dgvGrades
            // 
            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.AllowUserToDeleteRows = false;
            dgvGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrades.Dock = DockStyle.Fill;
            dgvGrades.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvGrades.Location = new Point(0, 30);
            dgvGrades.Margin = new Padding(3, 4, 3, 4);
            dgvGrades.Name = "dgvGrades";
            dgvGrades.RowHeadersWidth = 51;
            dgvGrades.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvGrades.Size = new Size(914, 570);
            dgvGrades.TabIndex = 1;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, actionsMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 3, 0, 3);
            menuStrip.Size = new Size(914, 30);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { saveMenuItem, loadMenuItem, aboutToolStripMenuItem, settingsToolStripMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(46, 24);
            fileMenu.Text = "File";
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.Size = new Size(224, 26);
            saveMenuItem.Text = "Save";
            // 
            // loadMenuItem
            // 
            loadMenuItem.Name = "loadMenuItem";
            loadMenuItem.Size = new Size(224, 26);
            loadMenuItem.Text = "Load";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(224, 26);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(224, 26);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // actionsMenu
            // 
            actionsMenu.DropDownItems.AddRange(new ToolStripItem[] { addStudentMenuItem, addAssignmentMenuItem, btnRemoveAssignment });
            actionsMenu.Name = "actionsMenu";
            actionsMenu.Size = new Size(72, 24);
            actionsMenu.Text = "Actions";
            // 
            // addStudentMenuItem
            // 
            addStudentMenuItem.Name = "addStudentMenuItem";
            addStudentMenuItem.Size = new Size(227, 26);
            addStudentMenuItem.Text = "Add Student";
            // 
            // addAssignmentMenuItem
            // 
            addAssignmentMenuItem.Name = "addAssignmentMenuItem";
            addAssignmentMenuItem.Size = new Size(227, 26);
            addAssignmentMenuItem.Text = "Add Assignment";
            // 
            // btnRemoveAssignment
            // 
            btnRemoveAssignment.Name = "btnRemoveAssignment";
            btnRemoveAssignment.Size = new Size(227, 26);
            btnRemoveAssignment.Text = "Remove Assignment";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(dgvGrades);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Gradebook";
            ((System.ComponentModel.ISupportInitialize)dgvGrades).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
    }
}

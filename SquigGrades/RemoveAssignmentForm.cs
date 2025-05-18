using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace SquigGrades
{
    public partial class RemoveAssignmentForm : Form
    {

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedAssignment { get; private set; }

        public RemoveAssignmentForm(List<string> assignments)
        {
            InitializeComponent();
            cmbAssignments.DataSource = assignments;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cmbAssignments.SelectedItem != null)
            {
                SelectedAssignment = cmbAssignments.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select an assignment to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

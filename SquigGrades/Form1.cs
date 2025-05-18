using System.Diagnostics;
using System.Reflection;

namespace SquigGrades
{
    public partial class Form1 : Form
    {
        private Gradebook gradebook = new();
        private string? currentFilePath = null; // Stores the current file path
        private bool isModified = false;       // Tracks whether the file has been modified
        private bool allowPrereleaseUpdates = false;

        public Form1()
        {
            InitializeComponent();
            InitializeMenuEventHandlers();
            InitializeData();
            gradebook.GradebookModified += Gradebook_GradebookModified;
            dgvGrades.CellValueChanged += DgvGrades_CellValueChanged;
            btnRemoveAssignment.Click += BtnRemoveAssignment_Click; // Add event handler
            CheckForUpdatesAsync();
        }

        private int selectedColumnIndex = -1; // Track the selected column index


        private void InitializeMenuEventHandlers()
        {
            saveMenuItem.Click += SaveMenuItem_Click;
            loadMenuItem.Click += LoadMenuItem_Click;
            addStudentMenuItem.Click += AddStudentMenuItem_Click;
            addAssignmentMenuItem.Click += AddAssignmentMenuItem_Click;
        }

        private void AddStudentMenuItem_Click(object sender, EventArgs e)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox("Enter student name:", "Add Student", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                var newStudent = new Student(gradebook.Students.Count + 1, input);
                gradebook.AddStudent(newStudent);
                RefreshGradeGrid();
            }
        }

        private void AddAssignmentMenuItem_Click(object sender, EventArgs e)
        {
            var name = Microsoft.VisualBasic.Interaction.InputBox("Enter assignment name:", "Add Assignment", "");
            var maxScoreInput = Microsoft.VisualBasic.Interaction.InputBox("Enter maximum score:", "Add Assignment", "100");

            if (!string.IsNullOrWhiteSpace(name) && double.TryParse(maxScoreInput, out double maxScore))
            {
                var newAssignment = new Assignment(name, maxScore);
                gradebook.AddAssignment(newAssignment);
                RefreshGradeGrid();
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                // Save directly to the current file path
                SaveGradebookToFile(currentFilePath);
                isModified = false; // Reset the modified flag
                UpdateWindowTitle(); // Update the window title
            }
            else
            {
                // Open the save dialog if no file path exists
                using var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Custom Gradebook Files (*.gbk)|*.gbk",
                    DefaultExt = "gbk"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName; // Update the current file path
                    SaveGradebookToFile(currentFilePath);
                    isModified = false; // Reset the modified flag
                    UpdateWindowTitle(); // Update the window title
                }
            }
        }



        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "Custom Gradebook Files (*.gbk)|*.gbk",
                DefaultExt = "gbk"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName; // Update the current file path
                var lines = File.ReadAllLines(currentFilePath);
                var section = string.Empty;

                gradebook = new Gradebook();

                foreach (var line in lines)
                {
                    if (line.StartsWith("#"))
                    {
                        section = line;
                    }
                    else if (section == "# Students")
                    {
                        var parts = line.Split(',');
                        var student = new Student(int.Parse(parts[0]), parts[1]);
                        gradebook.AddStudent(student);
                    }
                    else if (section == "# Assignments")
                    {
                        var parts = line.Split(',');
                        var assignment = new Assignment(parts[0], double.Parse(parts[1]));
                        gradebook.AddAssignment(assignment);
                    }
                    else if (section == "# Grades")
                    {
                        var parts = line.Split(',');
                        var studentId = int.Parse(parts[0]);
                        var assignmentName = parts[1];
                        var score = double.Parse(parts[2]);

                        gradebook.AssignGrade(studentId, assignmentName, score);
                    }
                }

                RefreshGradeGrid();
                isModified = false; // Reset the modified flag
                UpdateWindowTitle(); // Update the window title
            }
        }



        private void InitializeData()
        {
            RefreshGradeGrid();
        }

        private void RefreshGradeGrid()
        {
            dgvGrades.Columns.Clear();
            dgvGrades.Rows.Clear();

            // Add the first columns for Student Name, Final Grade, and Letter Grade
            dgvGrades.Columns.Add("StudentName", "Student Name");
            dgvGrades.Columns.Add("FinalGrade", "Final Grade (%)");
            dgvGrades.Columns.Add("LetterGrade", "Letter Grade");

            // Set fixed column width for the first three columns
            foreach (DataGridViewColumn column in dgvGrades.Columns)
            {
                column.Width = 150;
            }

            // Add columns for each assignment with the maximum score in the header
            foreach (var assignment in gradebook.Assignments)
            {
                var column = dgvGrades.Columns.Add(assignment.Name, $"{assignment.Name} ({assignment.MaxScore})");
                dgvGrades.Columns[column].Width = 150; // Set fixed width for assignment columns
            }

            // Populate rows with student data
            foreach (var student in gradebook.Students)
            {
                var finalGradePercentage = gradebook.GetFinalGradePercentage(student.ID);
                var row = new List<object>
        {
            student.Name,
            finalGradePercentage.ToString("F2"), // Final grade as a percentage
            GetLetterGrade(finalGradePercentage) // Letter grade
        };

                // Add scores for each assignment
                foreach (var assignment in gradebook.Assignments)
                {
                    if (student.Grades.TryGetValue(assignment.Name, out double score))
                    {
                        row.Add($"{score}/{assignment.MaxScore}"); // Display score as "X/Y"
                    }
                    else
                    {
                        row.Add(""); // Empty cell for no score
                    }
                }

                dgvGrades.Rows.Add(row.ToArray());
            }
        }


        private void DgvGrades_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 2) // Ignore the first three columns
            {
                var studentName = dgvGrades.Rows[e.RowIndex].Cells[0].Value.ToString();
                var assignmentHeader = dgvGrades.Columns[e.ColumnIndex].HeaderText;
                var assignmentName = assignmentHeader.Split('(')[0].Trim(); // Extract assignment name
                var cellValue = dgvGrades.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (double.TryParse(cellValue?.Split('/')[0], out double score))
                {
                    var student = gradebook.Students.FirstOrDefault(s => s.Name == studentName);
                    var assignment = gradebook.Assignments.FirstOrDefault(a => a.Name == assignmentName);

                    if (student != null && assignment != null)
                    {
                        gradebook.AssignGrade(student.ID, assignment.Name, score);
                        RefreshGradeGrid(); // Refresh the grid to update final grades and letter grades
                    }
                }
                else
                {
                    MessageBox.Show("Invalid score format. Please enter the score as 'X/Y'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string GetLetterGrade(double percentage)
        {
            if (percentage >= 97) return "A+";
            if (percentage >= 93 && percentage < 97) return "A";
            if (percentage >= 90 && percentage < 93) return "A-";
            if (percentage >= 87 && percentage < 90) return "B+";
            if (percentage >= 83 && percentage < 87) return "B";
            if (percentage >= 80 && percentage < 83) return "B-";
            if (percentage >= 77 && percentage < 80) return "C+";
            if (percentage >= 73 && percentage < 77) return "C";
            if (percentage >= 70 && percentage < 73) return "C-";
            if (percentage >= 67 && percentage < 70) return "D+";
            if (percentage >= 63 && percentage < 67) return "D";
            if (percentage >= 60 && percentage < 63) return "D-";
            return "F";
        }
        private void Gradebook_GradebookModified(object? sender, EventArgs e)
        {
            isModified = true; // Mark the file as modified
            Text = "Gradebook - Modified";
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }
        private void BtnRemoveAssignment_Click(object sender, EventArgs e)
        {
            var assignmentNames = gradebook.Assignments.Select(a => a.Name).ToList();
            if (assignmentNames.Count == 0)
            {
                MessageBox.Show("No assignments available to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var removeForm = new RemoveAssignmentForm(assignmentNames))
            {
                if (removeForm.ShowDialog() == DialogResult.OK)
                {
                    var assignmentName = removeForm.SelectedAssignment;

                    var confirmResult = MessageBox.Show(
                        $"Are you sure you want to remove the assignment '{assignmentName}'?",
                        "Confirm Removal",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmResult == DialogResult.Yes)
                    {
                        gradebook.RemoveAssignment(assignmentName);
                        RefreshGradeGrid();
                        MessageBox.Show($"Assignment '{assignmentName}' has been removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void SaveGradebookToFile(string filePath)
        {
            var lines = new List<string>();

            // Save students
            lines.Add("# Students");
            foreach (var student in gradebook.Students)
            {
                lines.Add($"{student.ID},{student.Name}");
            }

            // Save assignments
            lines.Add("# Assignments");
            foreach (var assignment in gradebook.Assignments)
            {
                lines.Add($"{assignment.Name},{assignment.MaxScore}");
            }

            // Save grades
            lines.Add("# Grades");
            foreach (var student in gradebook.Students)
            {
                foreach (var grade in student.Grades)
                {
                    lines.Add($"{student.ID},{grade.Key},{grade.Value}");
                }
            }

            // Write to file
            File.WriteAllLines(filePath, lines);
        }
        private void UpdateWindowTitle()
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                Text = $"Gradebook - {Path.GetFileName(currentFilePath)}{(isModified ? "*" : "")}";
            }
            else
            {
                Text = $"Gradebook - Untitled{(isModified ? "*" : "")}";
            }
        }
        private async Task CheckForUpdatesAsync()
        {
            string updateUrl = "https://raw.githubusercontent.com/Baldi627/squig-grades-version-check/refs/heads/main/version.json"; // Replace with your hosted JSON file URL
            try
            {
                using var httpClient = new HttpClient();
                string jsonResponse = await httpClient.GetStringAsync(updateUrl);

                Debug.WriteLine($"JSON Response: {jsonResponse}");

                // Parse the JSON response
                var jsonDocument = System.Text.Json.JsonDocument.Parse(jsonResponse);
                var root = jsonDocument.RootElement;

                // Explicitly set the properties of UpdateInfo
                var updateInfo = new UpdateInfo
                {
                    Version = root.GetProperty("version").GetString() ?? string.Empty,
                    IsPrerelease = root.GetProperty("isPrerelease").GetBoolean()
                };

                Debug.WriteLine($"Parsed UpdateInfo: Version={updateInfo.Version}, IsPrerelease={updateInfo.IsPrerelease}");

                if (string.IsNullOrWhiteSpace(updateInfo.Version))
                {
                    MessageBox.Show("Error parsing update information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                long latestVersionInt = ConvertVersionToInt(updateInfo.Version);
                long currentVersionInt = ConvertVersionToInt(AssemblyVersion);

                // Handle prerelease versions
                if (updateInfo.IsPrerelease && !allowPrereleaseUpdates)
                {
                    // Skip prerelease updates if the user has not opted in
                    return;
                }

                if (latestVersionInt > currentVersionInt)
                {
                    string prereleaseMessage = updateInfo.IsPrerelease
                        ? "\n\nNote: This is a prerelease version."
                        : "";

                    var result = MessageBox.Show(
                        $"A new version ({updateInfo.Version}) is available.{prereleaseMessage}\n\nWould you like to download it?",
                        "Update Available",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "https://github.com/Baldi627/SquigGrades/releases", // Replace with your download URL
                            UseShellExecute = true
                        });
                    }
                }
                else
                {
                    MessageBox.Show("You're using the Latest Version of SquigGrades! Good Jobies!", "No Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        private long ConvertVersionToInt(string version)
        {
            try
            {
                // Validate the version string format
                if (string.IsNullOrWhiteSpace(version) || !version.Contains("."))
                {
                    throw new FormatException("Invalid version format.");
                }

                // Split the version into segments and pad each segment to 3 digits
                var segments = version.Split('.').Select(s =>
                {
                    if (!int.TryParse(s, out _))
                    {
                        throw new FormatException($"Invalid version segment: {s}");
                    }

                    // Pad each segment to 3 digits
                    return s.PadLeft(3, '0');
                });

                // Concatenate the segments into a single string and parse as long
                return long.Parse(string.Join("", segments));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing version: {ex.Message}", version + ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Re-throw the exception to ensure it is logged or handled upstream
            }
        }




    }

}

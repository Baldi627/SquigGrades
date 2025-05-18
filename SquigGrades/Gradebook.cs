namespace SquigGrades
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Dictionary<string, double> Grades { get; set; } = new();

        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }

    public class Assignment
    {
        public string Name { get; set; }
        public double MaxScore { get; set; }

        public Assignment(string name, double maxScore)
        {
            Name = name;
            MaxScore = maxScore;
        }
    }

    public class Gradebook
    {
        public List<Student> Students { get; set; } = new();
        public List<Assignment> Assignments { get; set; } = new();

        public event EventHandler? GradebookModified;

        private void OnGradebookModified()
        {
            GradebookModified?.Invoke(this, EventArgs.Empty);
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            OnGradebookModified();
        }

        public void AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);
            OnGradebookModified();
        }

        public void AssignGrade(int studentId, string assignmentName, double score)
        {
            var student = Students.FirstOrDefault(s => s.ID == studentId);
            if (student != null)
            {
                student.Grades[assignmentName] = score;
                OnGradebookModified();
            }
        }

        public double GetTotalPointsEarned(int studentId)
        {
            var student = Students.FirstOrDefault(s => s.ID == studentId);
            if (student == null) return 0;

            return student.Grades.Sum(g => g.Value);
        }

        public double GetTotalPointsPossible()
        {
            return Assignments.Sum(a => a.MaxScore);
        }

        public double GetFinalGradePercentage(int studentId)
        {
            var totalPointsEarned = GetTotalPointsEarned(studentId);
            var totalPointsPossible = GetTotalPointsPossible();

            if (totalPointsPossible == 0) return 0;

            return (totalPointsEarned / totalPointsPossible) * 100;
        }
        public void RemoveAssignment(string assignmentName)
        {
            // Remove the assignment from the list
            Assignments.RemoveAll(a => a.Name == assignmentName);

            // Remove the assignment's grades from all students
            foreach (var student in Students)
            {
                if (student.Grades.ContainsKey(assignmentName))
                {
                    student.Grades.Remove(assignmentName);
                }
            }
        }

    }
}

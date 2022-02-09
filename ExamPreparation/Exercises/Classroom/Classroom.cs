using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return $"No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (this.students.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                Student foundedStudent = this.students.Where(s => s.FirstName == firstName && s.LastName == lastName).First();
                this.students.Remove(foundedStudent);
                return $"Dismissed student {foundedStudent.FirstName} {foundedStudent.LastName}";
            }

            return $"Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            if (this.students.Any(s => s.Subject == subject))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (var student in this.students)
                {
                    if (student.Subject == subject)
                    {
                        sb.AppendLine($"{student.FirstName} {student.LastName}");
                    }
                }

                return sb.ToString().TrimEnd();
            }

            return $"No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public string GetStudent(string firstName, string lastName)
        {
            Student foundedStudent = this.students.Where(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefault();
            return foundedStudent.ToString();
        }
    }
}

namespace StudentSystemCatalog.Students
{
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> students;

        public StudentSystem()
        {
            this.students = new Dictionary<string, Student>();
        }

        public void Add(string name, int age, double grade)
        {
            if (!this.students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.students[name] = student;
            }
        }

        public Student Get(string name)
        {
            if (this.students.ContainsKey(name))
            {
                var student = this.students[name];
                return student;
            }

            return null;
        }
    }
}

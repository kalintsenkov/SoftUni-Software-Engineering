namespace StudentSystemCatalog.Students
{
    using System.Text;

    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public double Grade { get; private set; }

        public override string ToString()
        {
            var studentInfo = new StringBuilder();

            studentInfo.Append($"{this.Name} is {this.Age} years old.");

            if (this.Grade >= 5.00)
            {
                studentInfo.Append(" Excellent student.");
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                studentInfo.Append(" Average student.");
            }
            else
            {
                studentInfo.Append(" Very nice person.");
            }

            return studentInfo.ToString().TrimEnd();
        }
    }
}
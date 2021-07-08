using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Q6
{
    class Program
    {
        class Student : IComparable<Student>
        {
            private string _name;
            private DateTime _dob;
            private int _semester;
            private double _gpa;

            public Student(string name, DateTime dob, int semester, double gpa)
            {
                this._name = name;
                this._dob = dob;
                this._semester = semester;
                this._gpa = gpa;
            }
            public string name { get; set; }
            public double gpa
            {
                get { return _gpa; }
                set
                {
                    _gpa = value;
                }
            }
            public DateTime dob { get; set; }
            public int semester { get; set; }
            public override string ToString()
            {
                return "Name : " + _name + "\nDate of Birth :" + _dob.ToShortDateString() + "\nSemester : " + _semester + "\nGpa : " + _gpa;
            }

            public int CompareTo(Student other)
            {
                if (this._gpa < other._gpa)
                    return 1;
                else if (this._gpa > other._gpa)
                    return -1;
                else
                    return 0;
            }
        }

        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student("Mustafa", new DateTime(2012, 12, 25), 1, 3.07));
            studentList.Add(new Student("Hassan", new DateTime(2012, 12, 25), 1, 4));
            studentList.Add(new Student("Ahsan", new DateTime(2012, 12, 25), 1, 3.86));
            studentList.Add(new Student("Noman", new DateTime(2012, 12, 25), 1, 3.53));

            studentList.Sort();
            foreach (Student s in studentList)
            {
                Console.WriteLine("Student # " + (studentList.IndexOf(s) + 1) + "\n" + s.ToString() + "\n");
            }

            Console.WriteLine("Press Any Key to Exit...");
            Console.ReadKey();
        }

    }
}

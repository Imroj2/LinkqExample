using System;
using System.Collections.Generic;
using System.Linq;

namespace Example_linQ
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating a list of students
            List<Student> students = new List<Student>
            {
                new Student { Name = "Ahmed", Age = 20, Grade = 90 },
                new Student { Name = "Mohamed", Age = 21, Grade = 80 },
                new Student { Name = "Ali", Age = 22, Grade = 70 },
                new Student { Name = "Khaled", Age = 23, Grade = 60 }
            };

            // LINQ operations

            // Filtering: Retrieve all the students whose age is greater than 20
            var studentAge20 = students.Where(s => s.Age > 20);

            // Filtering: Retrieve all students whose grade is greater than 80
            var studentGrade80 = students.Where(s => s.Grade > 80);

            // Filtering: Retrieve all students whose name starts with 'A'
            var studentNameA = students.Where(s => s.Name.StartsWith("A"));

            // Filtering: Retrieve all students whose name starts with 'A' and age is greater than 20
            var studentNameAandAge20 = students.Where(s => s.Name.StartsWith("A") && s.Age > 20);

            // Aggregation: Find the lowest grade
            var studentLowestGrade = students.Min(s => s.Grade);

            // Aggregation: Find the highest grade
            var studentHighestGrade = students.Max(s => s.Grade);

            // Grouping: Group students by age
            var groupByAge = students.GroupBy(s => s.Age);

            // Joining: Join students with itself based on the age
            var studentJoin = students.Join(students, s => s.Age, s => s.Age, (s1, s2) => new { Name1 = s1.Name, Name2 = s2.Name });

            //projection
            var studentProjection = students.Select(s => new { s.Name, s.Age });


            // Printing the results

            Console.WriteLine("Student whose age is greater than 20:");
            foreach (var item in studentAge20)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Student whose grade is greater than 80:");
            foreach (var item in studentGrade80)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Student whose name starts with 'A':");
            foreach (var item in studentNameA)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Student whose name starts with 'A' and age is greater than 20:");
            foreach (var item in studentNameAandAge20)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine($"Student who has the lowest grade ({studentLowestGrade}):");
            foreach (var item in students.Where(s => s.Grade == studentLowestGrade))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine($"Student who has the highest grade ({studentHighestGrade}):");
            foreach (var item in students.Where(s => s.Grade == studentHighestGrade))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Grouping by age:");
            foreach (var group in groupByAge)
            {
                Console.WriteLine($"Age: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($"  {student.Name}");
                }
            }

            Console.WriteLine("Joining (Names from both sides of the join):");
            foreach (var item in studentJoin)
            {
                Console.WriteLine($"Name1: {item.Name1}, Name2: {item.Name2}");
            }
            //projection
            Console.WriteLine("Projection (Name and Age):");
        }
    }
}

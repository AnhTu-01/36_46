using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonKpi
{
    // a. Abstract class Person
    public abstract class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public Person(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }

    // b. Interface Kpi
    public interface Kpi
    {
        float Kpi();
    }

    // c. Class Student
    public class Student : Person, Kpi
    {
        private string department;

        public string Department
        {
            get { return department; }
            set
            {
                if (value == "ICT" || value == "ECO")
                {
                    department = value;
                }
                else
                {
                    throw new ArgumentException("Department must be 'ICT' or 'ECO'");
                }
            }
        }

        public float Gpa { get; set; }

        public Student(string name, string id, string department, float gpa) : base(name, id)
        {
            if (id.Length == 8 && id.All(char.IsDigit))
            {
                Id = id;
            }
            else
            {
                throw new ArgumentException("ID must be 8 digits");
            }

            Department = department;
            Gpa = gpa;
        }

        public float Kpi()
        {
            return Gpa;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // d. Declaring obs as Person and assigning null
            Person obs = null;

            // e. Assigning obs as Student and displaying kpi
            try
            {
                obs = new Student("Nguyễn Tiến Dũng", "12345678", "ICT", 3.5f);
                Console.WriteLine($"KPI: {((Student)obs).Kpi()}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // g. Assigning obs with wrong id or department and viewing effect
            try
            {
                obs = new Student("Nguyễn Tiến Dũng", "1234", "XYZ", 3.5f);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // h. Declaring list1 and list2 and reading input
            List<Person> list1 = new List<Person>();
            List<Person> list2 = new List<Person>();

            Console.WriteLine("Nhập sinh viên ngồi bàn 1 lớp 23IT5 ngày 25/06/2024, kết thúc nhập nếu nhập name là #:");
            while (true)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (name == "#") break;

                Console.Write("ID: ");
                string id = Console.ReadLine();

                Console.Write("Department: ");
                string department = Console.ReadLine();

                Console.Write("GPA: ");
                float gpa = float.Parse(Console.ReadLine());

                try
                {
                    list1.Add(new Student(name, id, department, gpa));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Nhập sinh viên ngồi bàn 2 lớp 23IT6 ngày 25/06/2024, kết thúc nhập nếu nhập name là #:");
            while (true)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (name == "#") break;

                Console.Write("ID: ");
                string id = Console.ReadLine();

                Console.Write("Department: ");
                string department = Console.ReadLine();

                Console.Write("GPA: ");
                float gpa = float.Parse(Console.ReadLine());

                try
                {
                    list2.Add(new Student(name, id, department, gpa));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Display list1 and list2
            Console.WriteLine("List1:");
            foreach (var student in list1)
            {
                Console.WriteLine($"{student.Name}, {student.Id}, {((Student)student).Department}, {((Student)student).Gpa}");
            }

            Console.WriteLine("List2:");
            foreach (var student in list2)
            {
                Console.WriteLine($"{student.Name}, {student.Id}, {((Student)student).Department}, {((Student)student).Gpa}");
            }

            // k. Declaring list_list and adding list1, list2
            List<List<Person>> list_list = new List<List<Person>> { list1, list2 };

            // Display list_list
            Console.WriteLine("List_List:");
            foreach (var list in list_list)
            {
                foreach (var student in list)
                {
                    Console.WriteLine($"{student.Name}, {student.Id}, {((Student)student).Department}, {((Student)student).Gpa}");
                }
            }

            // l. Creating dictionary dict1 for list1 with id as key
            Dictionary<string, Student> dict1 = list1.Cast<Student>().ToDictionary(student => student.Id);

            // Searching for students named "Nam"
            var result = dict1.Values.Where(student => student.Name == "Nam").ToList();

            // Displaying found students
            if (result.Any())
            {
                Console.WriteLine("Found students named 'Nam':");
                foreach (var student in result)
                {
                    Console.WriteLine($"{student.Name}, {student.Id}, {student.Department}, {student.Gpa}");
                }
            }
            else
            {
                Console.WriteLine("No students named 'Nam' found.");
            }
        }
    }
}
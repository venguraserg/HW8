using System;

namespace HW8.Model
{
    public class Employee
    {
        
        public Guid Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Department Department { get; set; }

        public double Salary { get; set; } 

        public Employee(string surname,string name, int age, Department department,double salary)
        {
            Id = Guid.NewGuid();
            Surname = surname;
            Name = name;
            Age = age;
            Department = department;
            Salary = salary;

        }


    }
}

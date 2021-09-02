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

        public int Salary { get; set; } 

        public Employee(string surname,string name, int age, Department department,int salary)
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

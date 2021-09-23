using System;

namespace HW8.Model
{
    public class Employee
    {
        
        public Guid Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Guid IdDepartment { get; set; }

        public double Salary { get; set; } 

        public Employee(string surname,string name, int age, Guid idDepartment,double salary)
        {
            Id = Guid.NewGuid();
            Surname = surname;
            Name = name;
            Age = age;
            IdDepartment = idDepartment;
            Salary = salary;

        }

        
        public override string ToString()
        {
            return $"{this.Surname} {this.Name} возраст {this.Age} лет";
        }
    }
}

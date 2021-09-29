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

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Employee()
        {

        }
        /// <summary>
        /// Конструктор №1
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="idDepartment"></param>
        /// <param name="salary"></param>
        public Employee(string surname,string name, int age, Guid idDepartment,double salary)
        {
            Id = Guid.NewGuid();
            Surname = surname;
            Name = name;
            Age = age;
            IdDepartment = idDepartment;
            Salary = salary;

        }
        /// <summary>
        /// Конструктор №2
        /// </summary>
        /// <param name="id"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="idDepartment"></param>
        /// <param name="salary"></param>
        public Employee(Guid id, string surname, string name, int age, Guid idDepartment, double salary)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Age = age;
            IdDepartment = idDepartment;
            Salary = salary;

        }

        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Surname} {this.Name} возраст {this.Age} лет, заработная плата {this.Salary}";
        }
    }
}

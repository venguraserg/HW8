using System;
using System.Collections.Generic;

namespace HW8.Model
{
    public class Department
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Employee> Employees { get; set; }
        private int _numberEmployees;

        public Department()
        {
            Name = "";
        }

        public Department(string name)
        {
            Name = name;
            CreateDate = DateTime.Now;
            Employees = new List<Employee>();
        }

        public Department(string name, DateTime createDate, List<Employee> employees)
        {
            Name = name;
            CreateDate = createDate;
            Employees = employees;
        }

        public void AddEmployee(Employee employee) 
        {
            Employees.Add(employee);
        }

        public override string ToString()
        {
            return $"{this.Name} создан {this.CreateDate.ToShortDateString()} количество сотрудников {Employees.Count}";
        }


    }
}

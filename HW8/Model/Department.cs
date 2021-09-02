using System;
using System.Collections.Generic;

namespace HW8.Model
{
    public class Department
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int NumberEmployees { get; set; }
        public List<Employee> Employees { get; set; }

        public Department()
        {
            Name = "";
        }

        public void AddEmployee(Employee employee) 
        {
            Employees.Add(employee);
        }



    }
}

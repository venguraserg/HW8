using System;
using System.Collections.Generic;

namespace Model.Model
{
    public class Department
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int NumberEmployees { get; set; }
        public List<Employee> Employees { get; set; }
    }
}

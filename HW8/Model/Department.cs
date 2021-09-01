using System;
using System.Collections.Generic;

namespace HW8.Model
{
    public class Department
    {
        /* 
           Каждый департамент обладает как минимум следующими полями:

             Наименование.
             Дата создания.
             Количество сотрудников.
        */
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int NumberEmployees { get; set; }
        public List<Employee> Employees { get; set; }
    }
}

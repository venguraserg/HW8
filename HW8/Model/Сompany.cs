using System;
using System.Collections.Generic;
using System.Linq;

namespace HW8.Model
{
    public class Company
    {
        public string Name { get; set; }
        public List<Department> DepartmentsList { get; set; }
        public List<Employee> EmployeeList { get; set; }

        // конструктор для создания экземпляра класса компании
        public Company()
        {
            DepartmentsList = new List<Department>();
            EmployeeList = new List<Employee>();
            
        }
        #region Методы департамента
        // метод добавления департамента
        public void AddDepartment(Department department)
        {
            DepartmentsList.Add(department);
        }

        // метод удаления департамента
        public void RemoveDepartment(int index)
        {
            DepartmentsList.RemoveAt(index);
        }

        //Метод редактирования департамента
        public void EditDepartment(Department department, int index)
        {
            DepartmentsList[index] = department;
        }

        public string GetNameDepartment(Guid id)
        {
            return DepartmentsList.Single(i => i.IdDepartment == id).Name; ;
        }



        #endregion

        #region Методы Сотрудника
        // метод добавления департамента
        public void AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
        }

        internal void RemoveEmployee(int index)
        {
            EmployeeList.RemoveAt(index); 
        }

        /// <summary>
        /// Метод редактирования сотрудника
        /// </summary>
        /// <param name="department"></param>
        /// <param name="index"></param>
        public void EditEmployee(Employee employee, int index)
        {
            EmployeeList[index] = employee;
        }
        #endregion

    }
}

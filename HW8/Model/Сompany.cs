using System;
using System.Collections.Generic;
using System.Linq;

namespace HW8.Model
{
    public class Company
    {
        public string Name { get; set; }
        public List<Department> DepartmentsList { get; set; }
        //public List<Employee> EmployeeList { get; set; }
        public Dictionary<Employee,Department> EmployeeList { get; set; }

        /// <summary>
        /// конструктор для создания экземпляра класса компании
        /// </summary>
        public Company()
        {
            DepartmentsList = new List<Department>();
            EmployeeList = new Dictionary<Employee, Department>();
            
        }
        #region Методы департамента

        /// <summary>
        /// метод добавления департамента
        /// </summary>
        /// <param name="department"></param>
        public void AddDepartment(Department department)
        {
            DepartmentsList.Add(department);
        }
        /// <summary>
        /// метод удаления департамента
        /// </summary>
        /// <param name="index"></param>
        public void RemoveDepartment(int index)
        {
            DepartmentsList.RemoveAt(index);
        }

        /// <summary>
        /// Метод редактирования департамента
        /// </summary>
        /// <param name="department"></param>
        /// <param name="index"></param>
        public void EditDepartment(Department department, int index)
        {
            DepartmentsList[index] = department;
        }

        /// <summary>
        /// Получение Имени Департамента по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetIdDepartment(Guid id)
        {
            return "";// DepartmentsList.Single(i => i.IdDepartment == id).Name; ;
        }



        #endregion

        #region Методы Сотрудника
        /// <summary>
        /// метод добавления сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="department"></param>
        public void AddEmployee(Employee employee, Department department)
        {
            EmployeeList.Add(employee, department);
            
        }

        /// <summary>
        /// Метод удаления сотрудника
        /// </summary>
        /// <param name="employee"></param>
        internal void RemoveEmployee(Employee employee)
        {
            EmployeeList.Remove(employee);
        }

        //internal void EditEmployee(Employee employee)
        //{
        //    EmployeeList.Remove(employee);
        //}
        #endregion

    }
}

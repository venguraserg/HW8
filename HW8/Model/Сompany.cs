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

        
        /// <summary>
        /// конструктор для создания экземпляра класса компании
        /// </summary>
        public Company()
        {
            DepartmentsList = new List<Department>();
            EmployeeList = new List<Employee>();
            
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
        /// Метод получения имени департамента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNameDepartment(Guid id)
        {
            return DepartmentsList.Single(i => i.IdDepartment == id).Name; ;
        }



        #endregion

        #region Методы Сотрудника
        
        /// <summary>
        /// метод добавления департамента
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
            if(employee.IdDepartment != Guid.Empty)
            {
                DepartmentsList[GetDepartmentIndexByDepartmentList(employee.IdDepartment)].Count++;
            }
        }
        /// <summary>
        /// Метод удаления сотрудника
        /// </summary>
        /// <param name="index"></param>
        internal void RemoveEmployee(int index)
        {
            if (EmployeeList[index].IdDepartment != Guid.Empty)
            {
                DepartmentsList[GetDepartmentIndexByDepartmentList(EmployeeList[index].IdDepartment)].Count--;
            }
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
        private int GetDepartmentIndexByDepartmentList(Guid id)
        {
            for (int i = 0; i < DepartmentsList.Count; i++)
            {
                if (DepartmentsList[i].IdDepartment == id) return i;
            }
            return 0;
        }
    }
}

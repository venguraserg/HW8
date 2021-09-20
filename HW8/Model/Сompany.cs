using System.Collections.Generic;

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
    }
}

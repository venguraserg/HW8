using System;

namespace Model.Model
{
    public class Employee
    {
        /*
          Каждый сотрудник обладает как минимум следующими полями:

          Идентификатор.
          Фамилия.
          Имя.
          Возраст.
          Департамент, в котором он работает.
          Размер заработной платы.
        */
        public Guid Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Department Department { get; set; }

        public int Salary { get; set; } 


    }
}

using System;
using System.Collections.Generic;

namespace HW8.Model
{
    public class Department
    {
        public Guid IdDepartment { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int Count { get; set; }
        
        /// <summary>
        /// Конструктор №1
        /// </summary>
        public Department()
        {
            IdDepartment = Guid.Empty;
            Name = "Без департамента";
        }
        /// <summary>
        /// Конструктор №2
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Department(Guid id, string name)
        {
            IdDepartment = id;
            Name = name;
            CreateDate = DateTime.Now;            
        }
        /// <summary>
        /// Конструктор №3
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createDate"></param>
        public Department(Guid id, string name, DateTime createDate)
        {
            IdDepartment = id;
            Name = name;
            CreateDate = createDate;
        }

        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Name} создан {this.CreateDate.ToShortDateString()} количество сотрудников {this.Count}";
        }

        

    }
}

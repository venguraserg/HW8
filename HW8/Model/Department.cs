using System;
using System.Collections.Generic;

namespace HW8.Model
{
    public class Department
    {
        public Guid IdDepartment { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        

        public Department()
        {
            IdDepartment = Guid.Empty;
            Name = "Без департамента";
        }

        public Department(Guid id, string name)
        {
            IdDepartment = id;
            Name = name;
            CreateDate = DateTime.Now;            
        }

        public Department(Guid id, string name, DateTime createDate)
        {
            IdDepartment = id;
            Name = name;
            CreateDate = createDate;
        }

        
        public override string ToString()
        {
            return $"{this.Name} создан {this.CreateDate.ToShortDateString()}";
        }

        

    }
}

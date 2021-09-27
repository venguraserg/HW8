using System;
using System.Collections.Generic;

namespace HW8.Model
{
    public class Department
    {
        //public Guid IdDepartment { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        

        public Department()
        {
            //IdDepartment = Guid.Empty;
            Name = string.Empty;
        }

        public Department(string name)
        {
            //IdDepartment = Guid.NewGuid();
            Name = name;
            CreateDate = DateTime.Now;            
        }

        public Department(string name, DateTime createDate)
        {
            //IdDepartment = Guid.NewGuid();
            Name = name;
            CreateDate = createDate;
        }

        
        public override string ToString()
        {
            return $"{this.Name} создан {this.CreateDate.ToShortDateString()}";
        }

        

    }
}

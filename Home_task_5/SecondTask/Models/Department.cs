using System.Collections.Generic;

namespace task_2.Models
{
    public class Department
    {// якщо є департамент в такому вигляді, як у Вас. то вже нема необхідності в Subdepartment. Ще не до кінця відчуваєте ієрархічні структури. але видно, що по візуалізаці зроблено величезну роботу.
        public string DepartmentName { get; set; }
        public List<Product> Products { get; set; }
        public List<Department> DepartmentList { get; set; }
        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
            this.Products = new List<Product>();
            this.DepartmentList = new List<Department>();
        }
    }
}

//    public class MonoDepartment : Department
//    {
//        public string DepartmentName { get; set; }
//        public List<Product> Products { get; set; }
//        public MonoDepartment(string departmentName)
//        {
//            this.DepartmentName = departmentName;
//            Products = new List<Product>();
//        }
//        public MonoDepartment() { }
//    }

//    public class SubDepartment : Department
//    {
//        public string DepartmentName { get; set; }
//        public List<Department> DepartmentList { get; set; }

//        public SubDepartment(string depName)
//        {
//            this.DepartmentName= depName;
//            DepartmentList = new List<Department>();
//        }
//        public SubDepartment() { }
//    }
//}

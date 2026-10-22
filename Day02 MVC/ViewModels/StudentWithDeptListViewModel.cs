using Day02_MVC.Models;

namespace Day02_MVC.ViewModels
{
    public class StudentWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }

    }
}

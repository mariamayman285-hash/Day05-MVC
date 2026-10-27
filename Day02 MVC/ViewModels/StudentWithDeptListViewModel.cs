using Day02_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace Day02_MVC.ViewModels
{
    public class StudentWithDeptListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "name is required")]
        [RegularExpression(@"^[a-zA-Z1-9\s#]+$", ErrorMessage = "Only letters,numbers,spaces and # are allowed")]
        public string Name {  get; set; }

        [Range(18,30 , ErrorMessage ="Age between 18 and 30")]
        [Display(Name= "Student Age")]
        [Required(ErrorMessage ="Age is required")]
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }


        //dont forget to add the span for each one in view so the error message can appear

    }
}

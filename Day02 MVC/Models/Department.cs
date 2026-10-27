using System.ComponentModel.DataAnnotations;

namespace Day02_MVC.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage ="name is required")]
        [RegularExpression(@"^[a-zA-Z1-9\s#]+$" , ErrorMessage ="Only letters,numbers,spaces and # are allowed")]
        public string Name { get; set; }

        public string? MgrName { get; set; }       //in .net 8 everything in a class even strings are required (so we need to add nullable operator)

        //el navigation properties
        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
    }
}

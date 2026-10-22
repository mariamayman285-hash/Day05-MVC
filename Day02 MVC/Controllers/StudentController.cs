using Day02_MVC.Models;
using Day02_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Day02_MVC.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();
        StudentWithDeptListViewModel vm = new StudentWithDeptListViewModel();
        DepartmentBL departmentBL = new DepartmentBL();

        public IActionResult ShowAll()
        {
            List<Student> studentsList = studentBL.GetAll();
            return View("ShowAll",studentsList);
        }

        public IActionResult ShowDetails(int id)
        {
            Student student = studentBL.GetById(id);
            return View("ShowDetails",student);
        }

        //public IActionResult Add()      //the adding page itself
        //{
        //    return View("Add");
        //}

        //public IActionResult Add()
        //{
        //    vm.Departments= departmentBL.GetAll()
        //                                .Select(d=>new Department { Id=d.Id, Name=d.Name })
        //                                .ToList();
        //    return View("Add",vm);
        //}

        //[HttpPost]
        //public IActionResult SaveAdd(StudentWithDeptListViewModel studentSent)
        //{
        //    if (studentSent.Name != null)
        //    {
        //        Student student = new Student
        //        {
        //            Name = studentSent.Name,
        //            Age = studentSent.Age,
        //            DepartmentId = studentSent.DepartmentId
        //        };

        //        studentBL.AddStudent(student);
        //        return RedirectToAction("ShowAll");
        //    }

        //    studentSent.Departments = departmentBL.GetAll();
        //    return View("Add", studentSent);
        //}

        //public IActionResult Add(int id)
        //{
        //    Student student = studentBL.GetById(id);
        //    return View("Add", student);
        //}

        //public ActionResult Add()
        //{
        //    return View("Add");
        //}

        [HttpGet]
        public IActionResult Add()
        {
            StudentWithDeptListViewModel vm = new StudentWithDeptListViewModel();

            vm.Departments = departmentBL.GetAll();

            return View("Add", vm);
        }

        [HttpPost] 
        public ActionResult SaveAdd(Student StudentSent)
        {
            if (StudentSent.Name != null)
            {
                //save to the Db
                studentBL.AddStudent(StudentSent);
                return RedirectToAction(nameof(ShowAll)); 
            }
            return View("Add", StudentSent);
        }

        //public IActionResult Edit(int id)
        //{
        //    return View("Edit",studentBL.GetById(id));
        //}

        //public IActionResult SaveEdit(Student studentSent , int id)
        //{
        //    if (studentSent.Name != null)
        //    {
        //        Student oldStudent = studentBL.GetById(id);
        //        //update to local (controller)
        //        oldStudent.Name = studentSent.Name;
        //        oldStudent.Age = studentSent.Age;
        //        oldStudent.DepartmentId = studentSent.DepartmentId;

        //        //update to DB
        //        studentBL.EditStudent(oldStudent);

        //        //if saved
        //        return RedirectToAction(nameof(ShowAll));
        //    }
        //    return View("Edit" , studentSent);
        //}

        //public IActionResult Edit(int id)  //the [age itself
        //{
        //    Student stu=studentBL.GetById(id);
        //    List<Department> departmentList = departmentBL.GetAll();

        //    vm.Id = stu.Id;
        //    vm.Name = stu.Name;
        //    vm.Age = stu.Age;
        //    vm.DepartmentId = stu.DepartmentId;
        //    vm.Departments = departmentList;

        //    return View("Edit", vm);
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Sources
            Student stu = studentBL.GetById(id);
            List<Department> departmentList = departmentBL.GetAll();

            // Destination
            StudentWithDeptListViewModel vm = new StudentWithDeptListViewModel();

            // Mapping
            vm.Id = stu.Id;
            vm.Name = stu.Name;
            vm.Age = stu.Age;
            vm.DepartmentId = stu.DepartmentId;
            vm.Departments = departmentList;

            return View("Edit", vm);
        }

        // SaveEdit
        [HttpPost]
        public IActionResult SaveEdit(Student studentSent, int id)
        {
            if (studentSent.Name != null)
            {
                // Get old student
                Student oldStudent = studentBL.GetById(id);

                // Update locally
                oldStudent.Name = studentSent.Name;
                oldStudent.Age = studentSent.Age;
                oldStudent.DepartmentId = studentSent.DepartmentId;

                // Update to DB
                studentBL.EditStudent(oldStudent);

                return RedirectToAction(nameof(ShowAll));
            }

            return View("Edit", studentSent);
        }

        public ActionResult Delete(int id)
        {
            return View("Delete" , studentBL.GetById(id));
        }

        public IActionResult ConfirmDelete(int id)
        {
            Student stu = studentBL.GetById(id);
            
            if(stu != null)
            {
                //delete from db
                studentBL.DeleteStudent(stu);
                //if deleted
                return RedirectToAction(nameof(ShowAll));
            }
            return NotFound();
        }
    }

}

using Day02_MVC.Models;
using Day02_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Utils;

namespace Day02_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBL departmentBL = new DepartmentBL();

        public IActionResult Index()
        {
            List<Department> departmentsList = departmentBL.GetAll();
            return View("Index" , departmentsList);
        }

        public IActionResult Details(int id)
        {
            Department department = departmentBL.GetById(id);
            return View("Details", department);
        }

        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost] //so no one can access through the URL
        public ActionResult SaveAdd(Department DeptSent)
        {
            if(DeptSent.Name != null)
            {
                //save to the Db
                departmentBL.AddDept(DeptSent);
                return RedirectToAction(nameof(Index)); //better than duplication with (  return view("Index",DepartmentBL.GetAll()) )
            }
            return View("Add", DeptSent);
        }

        public IActionResult DetailsVM(int id)
        {
            Department dept = departmentBL.GetById(id);  //includes DeptName
            DeptExtraInfoViewModel viewModel = new DeptExtraInfoViewModel();

            viewModel.DeptName = dept.Name;                               //
            viewModel.StudentsInDeptByAge = new List<Student>();          //
            

            if (dept.Students!= null)
            {
                foreach(var student in dept.Students)
                {
                    if(student.Age>25)
                        viewModel.StudentsInDeptByAge.Add(student);
                }
            }

            string status = dept.Students.Count > 50 ? "Main" : "Branch";

            viewModel.DeptState = status;                                 //

            return View("DetailsVM" , viewModel);
        }


        public IActionResult Edit(int id)
        {
            Department dept = departmentBL.GetById(id);

            if(dept != null)
            {
                return View("Edit" , dept);     //the edit page with the old values of the chosen department
            }
            return NotFound();
        }

        public IActionResult SaveEdit(Department deptSent)
        {
            //if (deptSent.Name != null)
            if(ModelState.IsValid)
            {
                Department newDept = departmentBL.GetById(deptSent.Id);

                newDept.Name = deptSent.Name;
                newDept.MgrName = deptSent.MgrName;

                departmentBL.EditDept(newDept);

                return RedirectToAction("Index");

            }
            return View("Edit" , deptSent);
        }
    }
}

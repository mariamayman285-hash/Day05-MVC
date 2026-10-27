using Day02_MVC.data.DbContexts;
using Microsoft.EntityFrameworkCore;
namespace Day02_MVC.Models
{
    public class DepartmentBL
    {
        UniversityDbContext context = new UniversityDbContext();

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.Include(d=>d.Students).FirstOrDefault(d=> d.Id ==id);
        }

        public void AddDept(Department NewDeptData)
        {
            context.Departments.Add(NewDeptData);
            context.SaveChanges();
        }

        public void EditDept(Department oldDeptData)
        {
            context.Departments.Update(oldDeptData);
            context.SaveChanges();
        }
    }
}

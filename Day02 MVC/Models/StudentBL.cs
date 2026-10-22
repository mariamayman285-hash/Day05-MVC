using Day02_MVC.data.DbContexts;

namespace Day02_MVC.Models
{
    public class StudentBL
    {
        UniversityDbContext context = new UniversityDbContext();  //connection object

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(Student NewStudentData)
        {
            context.Students.Add(NewStudentData);
            context.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            context.Students.Update(student);   //dilemma !!question
            context.SaveChanges();
        }

        public void DeleteStudent(Student stu)
        {
            //delete from local
            context.Students.Remove(stu);
            //delete from Db
            context.SaveChanges();
        }
    }
}

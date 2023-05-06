namespace UniversityDB.Services
{
    using UniversityDB.Models.DataModels;
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithNoCourses();
    }
}

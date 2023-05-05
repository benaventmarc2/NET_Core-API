namespace UniversityDB.Models.DataModels
{
    using System.ComponentModel.DataAnnotations;
    public class Student : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public ICollection<Course> Courses { get; set; } = new List<Course>();        
    }
}

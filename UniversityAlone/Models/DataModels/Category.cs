namespace UniversityDB.Models.DataModels
{
    using System.ComponentModel.DataAnnotations;
    public class Category : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}

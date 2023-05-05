namespace UniversityDB.Models.DataModels
{
    using System.ComponentModel.DataAnnotations;
    public class BaseEntity
    {
        [Required, Key] 
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

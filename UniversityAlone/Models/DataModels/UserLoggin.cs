using System.ComponentModel.DataAnnotations;

namespace UniversityDB.Models.DataModels
{
    public class UserLoggin
    {
        [Required] public string UserName { get; set; }
        [Required] public string Password { get; set; }
    }
}

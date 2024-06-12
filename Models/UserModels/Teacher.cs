using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.UserModels
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public bool IsActive { get; set; }
        public IEnumerable<Class> Classes { get; set; }

    }
}

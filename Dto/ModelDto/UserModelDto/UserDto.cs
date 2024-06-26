using CenterEnglishManagement.Models.UserModels;

namespace CenterEnglishManagement.Dto.ModelDto.UserModelDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string? Mobile { get; set; }
        public DateTime? DOB { get; set; }
        public int? Gender { get; set; }
        public string? Address { get; set; }
    }
}

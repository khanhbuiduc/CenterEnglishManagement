using CenterEnglishManagement.Models.UserModels;

namespace CenterEnglishManagement.Dto.ModelDto.UserModelDto
{
    public class ParentDto:UserDto
    {

        public required string Mobile { get; set; }
        public string Address { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

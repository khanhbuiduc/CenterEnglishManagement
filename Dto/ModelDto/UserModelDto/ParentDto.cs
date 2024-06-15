using CenterEnglishManagement.Models.UserModels;

namespace CenterEnglishManagement.Dto.ModelDto.UserModelDto
{
    public class ParentDto:UserDto
    {

        public required string PhoneNumber { get; set; }
        public IEnumerable<Student> Chidrent { get; set; }
    }
}

using CenterEnglishManagement.Models.OtherModels;

namespace CenterEnglishManagement.Dto.ModelDto.UserModelDto
{
    public class TeacherDto : UserDto
    {
        public bool IsActive { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}

using CenterEnglishManagement.Models.OtherModels;

namespace CenterEnglishManagement.Dto.ModelDto.UserModelDto
{
    public class StudentDto:UserDto
    {
        public bool IsActive { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public int ParentId { get; set; }
        public int ClassId { get; set; }
        public ICollection<StudentAttendance> StudentAttendances { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}

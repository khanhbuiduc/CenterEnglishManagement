using CenterEnglishManagement.Models.OtherModels;
using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.UserModels
{
    public class Student:User
    {
        public bool IsActive { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public int ParentId { get; set; }
        public int ClassId {  get; set; }
        public ICollection<StudentAttendance> StudentAttendances { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}

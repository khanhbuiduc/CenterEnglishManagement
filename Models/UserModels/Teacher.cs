using System.ComponentModel.DataAnnotations;
using CenterEnglishManagement.Models.OtherModels;

namespace CenterEnglishManagement.Models.UserModels
{
    public class Teacher : User
    {

        public bool IsActive { get; set; }
        public int Mobile { get; set; }
        public DateTime DOB { get; set; }
        public bool Gender {  get; set; }
        public string Address { get; set; }
        public ICollection<Salary> Salaries { get; set; }
        public ICollection<Class> Classes { get; set; }

    }
}

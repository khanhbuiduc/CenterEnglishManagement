using CenterEnglishManagement.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.OtherModels
{
    public class Class
    {
        [Key] 
        
        public int Id { get; set; }
        public bool isActive { get; set; }
        public string Grade { get; set; }
        public int Year { get; set; }
        public string ClassName { get; set; }
        public ICollection<Student> Students { get; set; }


    }
}

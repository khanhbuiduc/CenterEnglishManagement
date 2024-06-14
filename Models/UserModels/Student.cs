using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.UserModels
{
    public class Student:User
    {
        public bool IsActive { get; set; }
        public bool ParentID { get; set; }
    }
}

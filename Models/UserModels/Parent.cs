using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.UserModels
{
    public class Parent:User
    {
        public required string PhoneNumber { get; set;}
        public IEnumerable<Student> Chidrent { get; set; }
    }
}

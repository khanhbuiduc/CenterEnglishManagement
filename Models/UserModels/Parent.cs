using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.UserModels
{
    public class Parent:User
    {
        public required string Mobile { get; set;}
        public string Address {  get; set;}
        public ICollection<Student> Students { get; set; }
    }
}

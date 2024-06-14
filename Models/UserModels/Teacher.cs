using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.UserModels
{
    public class Teacher : User
    {

        public bool IsActive { get; set; }
        public IEnumerable<Class> Classes { get; set; }

    }
}

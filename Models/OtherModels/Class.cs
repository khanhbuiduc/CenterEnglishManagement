using CenterEnglishManagement.Models.UserModels;

namespace CenterEnglishManagement.Models.OtherModels
{
    public class Class
    {
        public int Id { get; set; }
        public string Grade { get; set; }

        public int Year { get; set; }

        public string ClassNumber { get; set; }

        public string type { get; set; }//2 months, 6 months

        public bool isActive { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Student> Students { get; set; }


    }
}

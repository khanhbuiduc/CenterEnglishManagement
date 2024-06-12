using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.OtherModels
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Shift {  get; set; }
        public DateTime StartTime { get; set; }

    }
}

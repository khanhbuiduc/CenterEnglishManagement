namespace CenterEnglishManagement.Models.OtherModels
{
    public class Schedule
    {
        int Id { get; set; }
        public DateTime Date { get; set; }
        public int Shift {  get; set; }
        public DateTime StartTime { get; set; }

    }
}

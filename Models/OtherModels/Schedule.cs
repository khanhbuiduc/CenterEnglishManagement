using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.OtherModels
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public bool DateType { get; set; }
        // even: monday,wednesday,friday
        //odd: tueday,thursday,Saturday
        public int Shift {  get; set; }
        //Shift: 1,2,3
        public DateTime StartTime { get; set; }
        public int NumOfSession {  get; set; }
        //NumOfSession=36/72
        public int IdClass {  get; set; }

    }
}

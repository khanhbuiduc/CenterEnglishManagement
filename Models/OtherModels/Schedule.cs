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
        //Shift: 7h,14h,18h
        public DateTime StartTime { get; set; }
        public int NumOfSession {  get; set; }
        //NumOfSession=36/72
        public int ClassId {  get; set; }
        public Class? Class { get; set; }

    }
}

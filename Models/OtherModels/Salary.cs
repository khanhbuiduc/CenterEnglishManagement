using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.OtherModels
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        public int Amount {  get; set; }
        public DateTime Date { get; set; }
        public int teacherId {  get; set; }
    }
}

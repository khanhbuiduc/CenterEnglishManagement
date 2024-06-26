using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.OtherModels
{
    public class TuitionFee
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }//monthly
        public int ClassId { get; set; }
        public Class? Class { get;}

    }
}

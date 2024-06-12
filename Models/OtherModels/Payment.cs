using System.ComponentModel.DataAnnotations;

namespace CenterEnglishManagement.Models.OtherModels
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public DateTime Name { get; set; }
        public int  Amount { get; set; }
        public int TotalPaid { get; set; }
        public bool isFullPayment {  get; set; }
    }
}

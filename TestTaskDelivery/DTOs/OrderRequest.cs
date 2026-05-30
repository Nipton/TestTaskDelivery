using System.ComponentModel.DataAnnotations;

namespace TestTaskDelivery.DTOs
{
    public class OrderRequest
    {
        public int Id { get; set; }
        [Display(Name = "Город  отправителя")]
        public int SenderCityId { get; set; }
        [Display(Name = "Адрес отправителя")]
        public string SenderAddress { get; set; } = string.Empty;
        [Display(Name = "Город получателя")]
        public int ReceiverCityId { get; set; }
        [Display(Name = "Адрес получателя")]
        public string ReceiverAddress { get; set; } = string.Empty;
        [Display(Name = "Вес груза")]
        public decimal? Weight { get; set; }
        [Display(Name = "Дата забора груза")]
        public DateTime PickupDate { get; set; }
    }
}

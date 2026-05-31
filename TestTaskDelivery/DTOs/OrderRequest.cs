using System.ComponentModel.DataAnnotations;

namespace TestTaskDelivery.DTOs
{
    public class OrderRequest
    {
        public int Id { get; set; }

        [Display(Name = "Город  отправителя")]
        [Required(ErrorMessage = "Выберите город")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите город отправителя")]
        public int SenderCityId { get; set; }

        [Display(Name = "Адрес отправителя")]
        [Required(ErrorMessage = "Адрес обязателен")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Адрес должен содержать от 3 до 500 символов")]
        public string SenderAddress { get; set; } = string.Empty;

        [Display(Name = "Город получателя")]
        [Required(ErrorMessage = "Выберите город")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите город отправителя")]
        public int ReceiverCityId { get; set; }

        [Display(Name = "Адрес получателя")]
        [Required(ErrorMessage = "Адрес обязателен")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Адрес должен содержать от 3 до 500 символов")]
        public string ReceiverAddress { get; set; } = string.Empty;

        [Display(Name = "Вес груза")]
        [Range(0, double.MaxValue, ErrorMessage = "Значение веса должно быть положительным")]
        [Required(ErrorMessage = "Укажите вес груза")]
        public decimal Weight { get; set; }

        [Display(Name = "Дата забора груза")]
        [Required(ErrorMessage = "Укажите дату забора груза")]
        public DateTime PickupDate { get; set; }
    }
}

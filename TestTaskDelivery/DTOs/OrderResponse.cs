
namespace TestTaskDelivery.DTOs
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;

        public string SenderCityName { get; set; } = string.Empty;
        public string SenderAddress { get; set; } = string.Empty;

        public string ReceiverCityName { get; set; } = string.Empty;
        public string ReceiverAddress { get; set; } = string.Empty;

        public decimal Weight { get; set; }
        public DateTime PickupDate { get; set; }
    }
}

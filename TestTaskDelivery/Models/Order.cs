namespace TestTaskDelivery.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required string OrderNumber { get; set; }

        public City SenderCity { get; set; } = null!;
        public int SenderCityId { get; set; }
        public required string SenderAddress { get; set; }

        public City ReceiverCity { get; set; } = null!;
        public int ReceiverCityId { get; set; }
        public required string ReceiverAddress { get; set; }

        public decimal Weight { get; set; }
        public DateTime PickupDate { get; set; }
    }
}

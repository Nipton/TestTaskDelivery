namespace TestTaskDelivery.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required string OrderNumber { get; set; }

        public required City SenderCity { get; set; }
        public int SenderCityId { get; set; }
        public required string SenderAddress { get; set; }

        public required City ReceiverCity { get; set; }
        public int ReceiverCityId { get; set; }
        public required string ReceiverAddress { get; set; }

        public decimal Weight { get; set; }
        public DateTime PickupDate { get; set; }
    }
}

namespace TestTaskDelivery.DTOs
{
    public class OrderResult
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string? OrderNumber { get; set; }
        public string? ErrorMessage { get; set; }

    }
}

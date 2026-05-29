using TestTaskDelivery.Data;

namespace TestTaskDelivery.Services
{
    public class OrderService
    {
        private readonly ApplicationContext _context;
        public OrderService(ApplicationContext context)
        {
            _context = context;
        }

    }
}

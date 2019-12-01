namespace PetStore.Services.Implementations
{
    using Data;

    public class OrderService : IOrderService
    {
        private readonly PetStoreDbContext data;

        public OrderService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void CompleteOrder(int orderId)
        {
            var order = this.data
                .Orders
                .Find(orderId);

            order.Status = Data.Models.OrderStatus.Done;

            this.data.SaveChanges();
        }
    }
}

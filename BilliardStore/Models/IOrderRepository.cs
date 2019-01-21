namespace BilliardStore.Models
{

    public interface IOrderRepository
    {
        System.Linq.IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }

}

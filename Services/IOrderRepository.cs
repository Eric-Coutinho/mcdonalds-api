using System.Threading.Tasks;
using System.Collections.Generic;
using mcdonalds_api.Model;

namespace mcdonalds_api.Services;

using Model;

public interface IOrderRepository
{
    Task<int> CreateOrder(int storeId);
    Task CancelOrder(int orderId);
    Task<List<Product>> GetMenu(int orderId);
    Task<List<Product>> GetOrderItems(int orderId);
    Task AddItem(int orderId, int productId);
    Task RemoveItem(int orderId, int productId);
    Task FinishOrder(int orderId);
    Task DeliveryOrder(int orderId);

}
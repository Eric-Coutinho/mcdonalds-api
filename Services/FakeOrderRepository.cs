using System.Threading.Tasks;
using System.Collections.Generic;
using mcdonalds_api.Model;

namespace mcdonalds_api.Services;

using System;
using Model;

public class FakeOrderRepository : IOrderRepository
{
    int orderId = 42;

    public async Task<int> CreateOrder(int storeId)
    {
        return orderId;
    }

    public Task AddItem(int orderId, int productId)
    {
        throw new System.NotImplementedException();
    }

    public async Task CancelOrder(int orderId)
    {
        orderId = Random.Shared.Next();
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new System.NotImplementedException();
    }
}
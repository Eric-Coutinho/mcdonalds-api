using System;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using mcdonalds_api.Model;
namespace mcdonalds_api.Services;

public class OrderRepository : IOrderRepository
{
    private readonly McDataBaseContext ctx;
    public OrderRepository(McDataBaseContext ctx)
        => this.ctx = ctx;

    public async Task<int> CreateOrder(int storeId)
    {
        var selectedStore =
            from store in ctx.Stores
            where store.Id == storeId
            select store;

        if (!selectedStore.Any())
        {
            throw new Exception("Store doesn't exist");
        }

        var clientOrder = new ClientOrder();
        clientOrder.StoreId = storeId;
        clientOrder.OrderCode = "ABC123";

        ctx.Add(clientOrder);
        await ctx.SaveChangesAsync();

        return clientOrder.Id;
    }

    public async Task CancelOrder(int orderId)
    {
        var currentOrder = GetOrder(orderId);

        if (currentOrder is null)
            throw new Exception("The order doesn't exist.");

        ctx.Remove(currentOrder);
        await ctx.SaveChangesAsync();
    }

    public async Task AddItem(int orderId, int productId)
    {
        var order = GetOrder(orderId);

        if (order is null)
            throw new Exception("Order doesn't exist.");

        var products =
            from product in ctx.Products
            where product.Id == productId
            select product;

        var selectProduct = await products.FirstOrDefaultAsync();
        if (selectProduct is null)
            throw new Exception("Product doesn't exist.");

        var item = new ClientOrderItem();
        item.ClientOrderId = orderId;
        item.ProductId = productId;

        ctx.Add(item);
        await ctx.SaveChangesAsync();
    }

    public async Task RemoveItem(int orderId, int productId)
    {
        var order = GetOrder(orderId);

        if (order is null)
            throw new Exception("Order doesn't exist.");

        var items =
            from item in ctx.ClientOrderItems
            where item.ProductId == productId && item.ClientOrderId == orderId
            select item;

        var selectItems = await items.FirstOrDefaultAsync();
        if (selectItems is null)
            throw new Exception("Product doesn't exist.");

        ctx.Remove(selectItems);
        await ctx.SaveChangesAsync();
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new NotImplementedException();
    }

    private async Task<ClientOrder> GetOrder(int orderId)
    {
        var orders =
           from order in ctx.ClientOrders
           where order.Id == orderId
           select order;

        return await orders.FirstOrDefaultAsync();
    }
}

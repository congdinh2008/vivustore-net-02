using System;
using ViVuStore.MVC.Models;
using ViVuStore.MVC.Services.BaseServices;
using ViVuStore.MVC.UnitOfWork;
using ViVuStore.MVC.ViewModels;

namespace ViVuStore.MVC.Services;

public interface IOrderService: IBaseService<Order>
{
    Task<bool> OrderAsync(OrderRequestViewModel request);
}

public class OrderService: BaseService<Order>, IOrderService
{
    public OrderService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> OrderAsync(OrderRequestViewModel request)
    {
        // Begin Transaction
        var transaction = await _unitOfWork.Context.Database.BeginTransactionAsync();
        // Create Order
        var newOrder = new Order
        {
            Id = Guid.NewGuid(),
            OrderDate = DateTime.Now,
            ShippedAddress = request.ShippedAddress,
            ExpectedShippedDate = DateTime.Now.AddDays(2),
            ActualShippedDate = null,
            PhoneNumber = request.PhoneNumber
        };
        _unitOfWork.OrderRepository.Add(newOrder);
        // Check product and get all
        // Create OrderDetail
        foreach (var item in request.Products)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
            if (product == null)
            {
                await transaction.RollbackAsync();
                return false;
            }
            var orderDetail = new OrderDetail
            {
                OrderId = newOrder.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = product.Price * (1 - item.Discount),
            };
            _unitOfWork.OrderDetailRepository.Add(orderDetail);
        }
        // SaveChanges
        var result = await _unitOfWork.SaveChangesAsync();

        return result > 0;
    }
}

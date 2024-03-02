using ClassLibrary1.Data;
using ClassLibrary1.ETClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary1.ETClasses.Order;

namespace ClassLibrary1.Repositories
{
    public class OrderRepositores
    {

        private readonly PharmaDbContext _context;

        public OrderRepositores(PharmaDbContext context)
        {
            _context = context;
        }

        // Add a new order to the database
        public void AddOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        // Get all orders
        public IEnumerable<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        // Get order by ID
        public Orders GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }

        // Update an existing order
        // Update a cart item
        //public void UpdateCartItem(Orders Item)
        //{
        //    var existingCartItem = _context.Carts.Find(Item.MedicineId);
        //    if (existingCartItem != null)
        //    {
        //        _context.Entry(existingCartItem).CurrentValues.SetValues(Item);
        //        _context.SaveChanges();
        //    }
        //}

        public void UpdateOrder(Orders updatedOrder)
        {
            using (var context = new PharmaDbContext())
            {
                var existingOrder = context.Orders.Find(updatedOrder.OrderId);

                if (existingOrder != null)
                {
                    // Update properties as needed
                    existingOrder.OrderId = updatedOrder.OrderId;
                    existingOrder.MedicineId = updatedOrder.MedicineId;
                    existingOrder.OrderDate = updatedOrder.OrderDate;
                    existingOrder.Amount = updatedOrder.Amount;
                    existingOrder.OrderCost = updatedOrder.OrderCost;
                    existingOrder.IsFirstOrderDiscountApplied = updatedOrder.IsFirstOrderDiscountApplied;
                    existingOrder.IsRegularCustomerDiscountApplied = updatedOrder.IsRegularCustomerDiscountApplied;

                    context.SaveChanges();
                }
            }
        }

        // Remove an order
        public void RemoveOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}

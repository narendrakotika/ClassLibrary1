using ClassLibrary1.Data;
using ClassLibrary1.ETClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repositories
{
   
        public class CartRepository
        {
            private readonly PharmaDbContext dbContext;
            public CartRepository()
            {
                dbContext = new PharmaDbContext();
            }

            //Add a cart item to the database
            public void AddCartItem(Cart cartItem)
            {
                dbContext.Carts.Add(cartItem);
                dbContext.SaveChanges();
            }

            // Get all cart items
            public IEnumerable<Cart> GetAllCartItems()
            {
                return dbContext.Carts.ToList();
            }

            // Get cart items for a specific order
            public IEnumerable<Cart> GetCartItemsForOrder(int MedicineId)
            {
                return dbContext.Carts.Where(c => c.MedicineId == MedicineId).ToList();
            }

            //Update a cart item
            // Update a cart item
            public void UpdateCartItem(Cart cartItem)
            {
                var existingCartItem = dbContext.Carts.Find(cartItem.CartId);
                if (existingCartItem != null)
                {
                    dbContext.Entry(existingCartItem).CurrentValues.SetValues(cartItem);
                    dbContext.SaveChanges();
                }
            }

            // Remove a cart item
            public void RemoveCartItem(int cartItemId)
            {
                var cartItem = dbContext.Carts.Find(cartItemId);
                if (cartItem != null)
                {
                    dbContext.Carts.Remove(cartItem);
                    dbContext.SaveChanges();
                }
            }
        }
    }


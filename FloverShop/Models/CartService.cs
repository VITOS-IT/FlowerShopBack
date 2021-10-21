using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloverShop.Models
{
    public class CartService
    {
        private readonly ShopContext _context;
        public CartService(ShopContext shopContext)
        {
            _context = shopContext;
        }
        public List<Cart> GetAllBouquets()
        {
            List<Cart> bouquets = _context.Carts.ToList();
            return bouquets;
        }
        public Cart GetBouquet(string id)
        {
            try
            {
                Cart bouquet = null;
                bouquet = _context.Carts.FirstOrDefault(p => p.Name == id);
                return bouquet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;

        }
        public Cart AddBouquet(Cart bouquet)
        {
            try
            {
                Cart newBouquet = new Cart();
              //  newBouquet.Id = bouquet.Id;
                newBouquet.Name = bouquet.Name;
                newBouquet.Price = bouquet.Price;
                newBouquet.Quantity = bouquet.Quantity;
                newBouquet.Description = bouquet.Description;

                _context.Carts.Add(newBouquet);
                _context.SaveChanges();
                return newBouquet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public Cart UpdateBouquet(string id, Cart bouquet)
        {
            try
            {
                var newBouquet = _context.Carts.FirstOrDefault(p => p.Name == id);
                newBouquet.Id = bouquet.Id;
              
                newBouquet.Name = bouquet.Name;
                newBouquet.Price = bouquet.Price;
                newBouquet.Quantity = bouquet.Quantity;
                newBouquet.Description = bouquet.Description;

                _context.Carts.Update(newBouquet);
                _context.SaveChanges();
                return newBouquet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}

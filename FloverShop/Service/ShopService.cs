using FloverShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloverShop.Service
{
    public class ShopService
    {
        private readonly ShopContext _context;
        public ShopService(ShopContext shopContext)
        {
            _context = shopContext;
        }
        public List<Bouquet> GetAllBouquets()
        {
            List<Bouquet> bouquets = _context.Bouquets.ToList();
            return bouquets;
        }
        public Bouquet GetBouquet(string id)
        {
            try
            {
                Bouquet bouquet = null;
                bouquet = _context.Bouquets.FirstOrDefault(p => p.Name == id);
                return bouquet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
           
        }
        public Bouquet AddBouquet(Bouquet bouquet)
        {
            try
            {
                Bouquet newBouquet = new Bouquet();
                newBouquet.Id = bouquet.Id;
                newBouquet.Name = bouquet.Name;
                newBouquet.Price = bouquet.Price;
                newBouquet.Quantity = bouquet.Quantity;
                newBouquet.Description = bouquet.Description;
                
                _context.Bouquets.Add(newBouquet);
                _context.SaveChanges();
                return newBouquet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public Bouquet UpdateBouquet(string id, Bouquet bouquet)
        {
            try
            {
                var newBouquet = _context.Bouquets.FirstOrDefault(p => p.Name == id);
                newBouquet.Id = bouquet.Id;
                newBouquet.Name = bouquet.Name;
                newBouquet.Price = bouquet.Price;
                newBouquet.Quantity = bouquet.Quantity;
                newBouquet.Description = bouquet.Description;

                _context.Bouquets.Update(newBouquet);
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

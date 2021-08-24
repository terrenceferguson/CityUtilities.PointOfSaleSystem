using CityUtilities.PointOfSaleSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityUtilities.PointOfSaleSystem.Data.Memory
{
    public class InMemoryProductRepository : IProductRepository
    {
        readonly List<Product> _products = new();

        public InMemoryProductRepository()
        {
            _products = new List<Product>()
            { 
                new Product
                {
                    Id = 1,
                    Title = "NVIDIA GeForce RTX 3080 10GB GDDR6X PCI Express 4.0 Graphics Card - Titanium and Black",
                    Price = 699.99,
                    StockNumber = "1000000"
                },
                new Product
                {
                    Id = 1,
                    Title = "NVIDIA GeForce RTX 3080 Ti 12GB GDDR6X PCI Express 4.0 Graphics Card - Titanium and Black",
                    Price = 1199.99,
                    StockNumber = "1000001"
                },
                new Product
                {
                    Id = 1,
                    Title = "NVIDIA GeForce RTX 3090 24GB GDDR6X PCI Express 4.0 Graphics Card - Titanium and Black",
                    Price = 1499.99,
                    StockNumber = "1000002"
                }
            };
        }

        public int Commit()
        {
            return 0;
        }

        public void Delete(int id)
        {
            _products.RemoveAll(x => x.Id == id);
        }

        public Product Get(int id)
        {
            return _products.Find(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public void Insert(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            product.Id = product.Id;
            product.Title = product.Title;
            product.Price = product.Price;
            product.StockNumber = product.StockNumber;
        }
    }
}

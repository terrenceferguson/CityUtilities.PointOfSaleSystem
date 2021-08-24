using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityUtilities.PointOfSaleSystem.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string StockNumber { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public ICollection<ProductStoreLocation> StoreLocations { get; set; }
        public ICollection<SalesOrderProduct> SalesOrders {  get; set; }
    }
}

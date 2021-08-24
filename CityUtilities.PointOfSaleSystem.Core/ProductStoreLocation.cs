using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityUtilities.PointOfSaleSystem.Core
{
    public class ProductStoreLocation
    {
        public int ProductId { get; set; }
        
        public int StoreLocationId { get; set; }


        public Product Product { get; set; }
        public StoreLocation StoreLocation { get; set; }
        
        public int Quantity { get; set; }
    }
}

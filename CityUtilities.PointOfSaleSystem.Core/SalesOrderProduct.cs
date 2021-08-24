using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityUtilities.PointOfSaleSystem.Core
{
    public class SalesOrderProduct
    {
        public int SalesOrderId { get; set; }
        
        public int ProductId { get; set; }


        public SalesOrder SalesOrder { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityUtilities.PointOfSaleSystem.Core
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime? SaleDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public ICollection<SalesOrderProduct> Products { get; set; }
    }
}

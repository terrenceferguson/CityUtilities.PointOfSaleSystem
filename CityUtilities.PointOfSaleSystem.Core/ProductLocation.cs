using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityUtilities.PointOfSaleSystem.Core
{
    public class ProductLocation
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public AisleEnum AisleId { get; set; }
        public virtual Aisle Aisle { get; set; }
        public int Quantity { get; set; }
    }
}

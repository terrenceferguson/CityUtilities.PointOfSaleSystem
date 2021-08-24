using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityUtilities.PointOfSaleSystem.Core
{
    public class StoreLocation
    {
        public enum Aisle
        {
            A, B, C, D, E, F, G
        }

        public int Id { get; set; }

        public Aisle AisleId { get; set; }

        public ICollection<ProductStoreLocation> Products { get; set; }
    }
}

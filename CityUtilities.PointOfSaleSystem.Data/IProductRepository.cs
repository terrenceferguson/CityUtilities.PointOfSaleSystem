using CityUtilities.PointOfSaleSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityUtilities.PointOfSaleSystem.Data
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(int id);

        int Commit();
    }
}

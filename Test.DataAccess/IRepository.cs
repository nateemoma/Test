using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataModel;

namespace Test.DataAccess
{
    public interface IRepository
    {
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> GetProducts();
    }
}

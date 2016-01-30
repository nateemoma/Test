using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess;
using Test.DataModel;

namespace Test.BusinessLogic
{
    public class Process
    {
        IRepository repository;

        public Process()
        {
            repository = new Repository();
        }

        public void InsertProduct(Product product)
        {
            try
            {
                repository.InsertProduct(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                repository.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                repository.DeleteProduct(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                return repository.GetProducts();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

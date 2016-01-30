using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataModel;

namespace Test.DataAccess
{
    public class Repository : IRepository
    {   
        public void InsertProduct(Product product)
        {
            using (TestDatabaseEntities db = new TestDatabaseEntities())
            {
                try
                {
                    product.Modified = DateTime.Now;

                    db.Products.Add(product);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }

        public void UpdateProduct(Product product)
        {
            using (TestDatabaseEntities db = new TestDatabaseEntities())
            {
                try
                {
                    var model = db.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

                    if (model == null)
                        return;

                    model.ProductName = product.ProductName;
                    model.Price = product.Price;
                    model.Info = product.Info;
                    model.Image = product.Image;
                    model.Live = product.Live;
                    model.Status = product.Status;
                    model.Visible = product.Visible;
                    model.Modified = DateTime.Now;

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public void DeleteProduct(Product product)
        {
            using (TestDatabaseEntities db = new TestDatabaseEntities())
            {
                try
                {
                    var query = db.Products.Where(x => x.ProductId == product.ProductId);

                    if (!query.Any())
                        return;

                    var _product = query.First();

                    db.Products.Remove(_product);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public List<Product> GetProducts()
        {
            using (TestDatabaseEntities db = new TestDatabaseEntities())
            {
                try
                {
                    var query = db.Products;
                    if (query.Any())
                    {
                        return query.ToList();
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }
    }
}

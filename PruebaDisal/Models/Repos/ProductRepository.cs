using PruebaDisal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDisal.Models.Repos
{
    public class ProductRepository : IProductRepository
    {
        DBCONTEXT dBCONTEXT = new DBCONTEXT();

        public bool deletProduct(Product product)
        {
            bool success = false;
            try
            {
                dBCONTEXT.Remove(product);
                dBCONTEXT.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return success;
        }

        public bool saveProduct(Product product)
        {
            bool success = false;
            try
            {
                dBCONTEXT.Add(product);
                dBCONTEXT.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return success;
        }

        public bool updateProduct(Product product)
        {
            bool success = false;
            try
            {
                dBCONTEXT.Update(product);
                dBCONTEXT.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return success;
        }

        public IEnumerable<Product> selectProducts()
        {
            try
            {
                return dBCONTEXT.Products.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

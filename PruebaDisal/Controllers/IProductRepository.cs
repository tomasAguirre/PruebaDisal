using PruebaDisal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDisal.Controllers
{
    public interface IProductRepository
    {
        bool saveProduct(Product product);

        bool updateProduct(Product product);

        bool deletProduct(Product product);

        IEnumerable<Product> selectProducts();
    }
}

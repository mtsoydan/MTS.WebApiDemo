using MTS.WebApiDemo.Entities;
using MTS.WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTS.WebApiDemo.DataAcces
{
    public class EfProductDal : EFRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductModel> GetProductWithModel()
        {
            //category ve product tabloları arasında join işlemi gerçekleştirildi

           using (NorthwindContext context = new NorthwindContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                             on product.CategoryID equals category.CategoryID
                             select new ProductModel {

                                 CategoryName = category.CategoryName,
                                 ProductID = product.ProductID,
                                 ProductName = product.ProductName,
                                 UnitPrice=product.UnitPrice
                             };
                return result.ToList();
            }
        }
    }
}

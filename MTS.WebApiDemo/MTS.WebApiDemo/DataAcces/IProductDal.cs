using MTS.WebApiDemo.Entities;
using MTS.WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.WebApiDemo.DataAcces
{
   public interface IProductDal : IEntityRepository<Product>
    {
        //Ürüne ait kendi özellikleri için bu interfacei kullanacağız

        List<ProductModel> GetProductWithModel();
    }
}

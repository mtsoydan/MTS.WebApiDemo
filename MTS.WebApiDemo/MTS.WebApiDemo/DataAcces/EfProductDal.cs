using MTS.WebApiDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTS.WebApiDemo.DataAcces
{
    public class EfProductDal : EFRepositoryBase<Product,NorthwindContext>, IProductDal
    {
       
    }
}

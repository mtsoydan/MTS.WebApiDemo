using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.WebApiDemo.Entities
{
    public class Product :IEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID{ get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }
    }
}

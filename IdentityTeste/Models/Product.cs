using RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTeste.Models
{
    [Table("products")]
    public class Product
    {
        [PrimaryKey]
        [IdentityIgnore]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}

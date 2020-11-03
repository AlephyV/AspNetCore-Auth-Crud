using Dapper;
using IdentityTeste.Models;
using IdentityTeste.Models.ViewModels.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RepositoryHelpers;
using RepositoryHelpers.DataBase;
using RepositoryHelpers.DataBaseRepository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Razor.Language;

namespace IdentityTeste.Repository
{
    public class ProductRepository
    {

        private readonly CustomRepository<Product> Repository;

        public ProductRepository()
        {

            

            var connection = new Connection()
            {
                Database = RepositoryHelpers.Utils.DataBaseType.SqlServer, 
                ConnectionString = "Password=eu;Persist Security Info=True;User ID=eu;Initial Catalog=tarefasdb;Data Source=DESKTOP-5H5NEP2"
            };

            Repository = new CustomRepository<Product>(connection);

        }

        public void Add(ProductCadastroVM product)
        {

            Product produto = new Product();
            produto.Name = product.Name;
            produto.Price = product.Price;
            produto.Quantity = product.Quantity;

            Repository.Insert(produto, true);

        }

        public IEnumerable<Product> GetAll()
        {
            string query = "SELECT * FROM products";
            return Repository.Get(query);
        }

        public Product Get(int id)
        {
            return Repository.GetById(id);
        }

        public void Delete(int id)
        {
           
            Repository.Delete(id);
        }

        public void Update(ProductAtualizarVM product)
        {
            Product produto = new Product();
            produto.ProductID = product.ProductID;
            produto.Name = product.Name;
            produto.Price = product.Price;
            produto.Quantity = product.Quantity;

            Repository.Update(produto);
        }
    }
}

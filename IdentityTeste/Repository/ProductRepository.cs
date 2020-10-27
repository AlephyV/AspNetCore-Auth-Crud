using Dapper;
using IdentityTeste.Models;
using IdentityTeste.Models.ViewModels.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTeste.Repository
{
    public class ProductRepository
    {

        public string GetConnection()
        {
            var connection = "Password=eu;Persist Security Info=True;User ID=eu;Initial Catalog=tarefasdb;Data Source=DESKTOP-5H5NEP2";
            return connection;
        }

        public void Add(ProductCadastroVM product)
        {
            var connectionString = this.GetConnection();

            using (var con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO products (Name, Quantity, Price) VALUES (@Name, @Quantity, @Price)";
                con.Open();
                con.Execute(query, product);
            }

        }

        public IEnumerable<Product> GetAll()
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM products";
                con.Open();
                return con.Query<Product>(query);
            }
        }

        public Product Get(int id)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM products WHERE ProductID=@id";
                con.Open();
                return con.Query<Product>(query, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM products WHERE ProductID=@id";
                con.Open();
                con.Execute(query, new { Id = id });
            }
        }

        public void Update(ProductAtualizarVM product)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                string query = "UPDATE products SET Name=@Name, Quantity=@Quantity, Price=@Price WHERE ProductID=@ProductID";
                con.Open();
                con.Query(query, product);
            }
        }
    }
}

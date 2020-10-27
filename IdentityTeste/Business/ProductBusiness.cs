using IdentityTeste.Models;
using IdentityTeste.Models.ViewModels.ProductViewModel;
using IdentityTeste.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTeste.Business
{
    public class ProductBusiness
    {

        public readonly ProductRepository productRepository;

        public ProductBusiness()
        {
            this.productRepository = new ProductRepository();
        }

        public IEnumerable<Product> Get()
        {
            return this.productRepository.GetAll();
        }

        public Product Get(int id)
        {
            return this.productRepository.Get(id);
        }

        public void Add(ProductCadastroVM product)
        {
            this.productRepository.Add(product);
        }

        public void Update(ProductAtualizarVM product)
        {
            Console.WriteLine(product);
            this.productRepository.Update(product);
        }

        public void Delete(int id)
        {
            this.productRepository.Delete(id);
        }

        public List<ProductListagemVM> ListaProdutos()
        {
            List<ProductListagemVM> listaProductsViewModel = new List<ProductListagemVM>();

            IEnumerable<Product> products = this.Get();
            List<Product> produtos = new List<Product>();

            foreach (var produto in products)
            {
                ProductListagemVM p = new ProductListagemVM();
                p.Name = produto.Name;
                p.Price = produto.Price;
                p.ProductID = produto.ProductID;
                p.Quantity = produto.Quantity;
                listaProductsViewModel.Add(p);
            }

            return listaProductsViewModel;

        }
    }
}

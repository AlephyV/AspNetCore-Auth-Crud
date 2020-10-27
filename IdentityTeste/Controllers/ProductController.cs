using IdentityTeste.Business;
using IdentityTeste.Models;
using IdentityTeste.Models.ViewModels.ProductViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTeste.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ProductBusiness productBusiness;
        List<ProductListagemVM> listaProductsViewModel;

        public ProductController()
        {
            productBusiness = new ProductBusiness();
        }

        public IActionResult Atualizar(int id)
        {
            Product produto = this.productBusiness.Get(id);
            ProductAtualizarVM produtoVM = new ProductAtualizarVM();

            produtoVM.Name = produto.Name;
            produtoVM.Price = produto.Price;
            produtoVM.ProductID = produto.ProductID;
            produtoVM.Quantity = produto.Quantity;

            return View(produtoVM);
        }

        public IActionResult Index()
        {
            this.listaProductsViewModel = this.productBusiness.ListaProdutos();
            return View(listaProductsViewModel);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IEnumerable<Product> Get()
        {
            return productBusiness.Get();
        }

        public Product Get(int id)
        {
            return productBusiness.Get(id);
        }

        [HttpPost]
        public IActionResult Post(ProductCadastroVM product)
        {
            if (ModelState.IsValid)
            {
                productBusiness.Add(product);
                this.listaProductsViewModel = this.productBusiness.ListaProdutos();
                return View("Index", this.listaProductsViewModel);
            }
            else
            {
                return View("Cadastrar", product);
            }


        }


        [HttpPost]
        public IActionResult Put(ProductAtualizarVM product)
        {
            if (ModelState.IsValid)
            {
                productBusiness.Update(product);

                this.listaProductsViewModel = this.productBusiness.ListaProdutos();
                return RedirectToAction("Index", this.listaProductsViewModel);
            }
            else
            {
                return View("Atualizar", product);
            }

        }

        public IActionResult Delete(int id)
        {
            productBusiness.Delete(id);
            this.listaProductsViewModel = this.productBusiness.ListaProdutos();

            return RedirectToAction("Index", this.listaProductsViewModel);


        }

    }
}

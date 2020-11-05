using IdentityTeste.Business;
using IdentityTeste.Hubs;
using IdentityTeste.Models;
using IdentityTeste.Models.ViewModels.ProductViewModel;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<LogHub> _logHubContext;
        List<ProductListagemVM> listaProductsViewModel;

        public ProductController(IHubContext<LogHub> loghub )
        {
            productBusiness = new ProductBusiness();
            _logHubContext = loghub;
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
                this._logHubContext.Clients.All.SendAsync("AcaoRecebida", User.Identity.Name, $"adicionou um novo produto as {DateTime.Now}");
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
                this._logHubContext.Clients.All.SendAsync("AcaoRecebida", User.Identity.Name, $"atualizou um produto as {DateTime.Now}");
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
            this._logHubContext.Clients.All.SendAsync("AcaoRecebida", User.Identity.Name, $"deletou um produto as {DateTime.Now}");
            productBusiness.Delete(id);
            this.listaProductsViewModel = this.productBusiness.ListaProdutos();

            return RedirectToAction("Index", this.listaProductsViewModel);


        }

    }
}

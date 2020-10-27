using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTeste.Models.ViewModels.ProductViewModel
{
    public class ProductCadastroVM
    {
        [Required(ErrorMessage = "O nome não pode ficar vazio")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "O nome deve estar entre 4 e 200 caracteres")]
        public string Name { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Quantidade inválida!")]
        public int Quantity { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Preço inválido!")]
        [Range(1, 1000, ErrorMessage = "O preço deve estar entre R$1 e R$1000")]
        public double Price { get; set; }
    }
}

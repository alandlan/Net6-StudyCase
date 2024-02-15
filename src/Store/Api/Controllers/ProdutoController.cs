using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net6StudyCase.Store.Domain.UseCases;
using SharedKernel.ViewModel;
using System.Security.Claims;

namespace ApiStore.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutoController : Controller
    {
        private readonly ICreateProduct createProduct;

        public ProdutoController(ICreateProduct createProduct)
        {
            this.createProduct = createProduct;
        }

        [HttpPost]
        [Authorize("Admin")]
        public async Task<ActionResult> CadastrarProduto(CreateProdutoViewModel produtoDto)
        {
            try
            {
                var user = User.Identity;

                await createProduct.Create(produtoDto);

                return Ok("Produto cadastrado");
            }
            catch 
            {
                return BadRequest("Falha ao cadastrar produto!");
            }
        }
    }
}
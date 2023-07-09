using Microsoft.AspNetCore.Mvc;
using Net6StudyCase.Store.Domain.UseCases;
using SharedKernel.ViewModel;

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
        public async Task<ActionResult> CadastrarProduto(CreateProdutoViewModel produtoDto)
        {
            try
            {
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
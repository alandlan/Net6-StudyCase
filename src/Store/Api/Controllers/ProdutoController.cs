using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net6StudyCase.Store.Domain.UseCases;
using SharedKernel.ViewModel;

namespace ApiStore.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutoController : Controller
    {
        private readonly ICreateProduct _createProduct;
        private readonly IGetProducts _getProducts;

        public ProdutoController(ICreateProduct createProduct, IGetProducts getProducts)
        {
            _createProduct = createProduct;
            _getProducts = getProducts;
        }

        [HttpPost]
        [Authorize("Admin")]
        public async Task<ActionResult> CadastrarProduto(CreateProdutoViewModel produtoDto)
        {
            try
            {
                var user = User.Identity;

                await _createProduct.Create(produtoDto);

                return Ok("Produto cadastrado");
            }
            catch 
            {
                return BadRequest("Falha ao cadastrar produto!");
            }
        }

        [HttpGet]
        public async Task<ActionResult> ListarProdutos()
        {
            try
            {
                var produtos = await _getProducts.GetAll();

                return Ok(produtos);
            }
            catch
            {
                return BadRequest("Falha ao listar produtos!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ListarProdutoPorId(int id)
        {
            try
            {
                var produto = await _getProducts.GetById(id);

                return Ok(produto);
            }
            catch
            {
                return BadRequest("Falha ao listar produto!");
            }
        }

        [HttpGet("pagination")]
        public async Task<ActionResult> ListarProdutosPaginados(int page, int pageSize)
        {
            try
            {
                var produtos = await _getProducts.GetPagination(page, pageSize);

                return Ok(produtos);
            }
            catch
            {
                return BadRequest("Falha ao listar produtos!");
            }
        }
    }
}
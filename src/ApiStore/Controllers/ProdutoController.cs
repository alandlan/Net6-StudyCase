using ApiStore.Data;
using AutoMapper;
using Library.Dtos;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiStore.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutoController : Controller
    {
        private IMapper _mapper;
        private readonly ProdutoDbContext _produtoDbContext;

        public ProdutoController(IMapper mapper, ProdutoDbContext produtoDbContext)
        {
            _mapper = mapper;
            _produtoDbContext = produtoDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarProduto(CreateProdutoDto produtoDto)
        {
            try
            {
                Produto usuario = _mapper.Map<Produto>(produtoDto);

                await _produtoDbContext.AddAsync(usuario);

                await _produtoDbContext.SaveChangesAsync();

                return Ok("Produto cadastrado");
            }
            catch (System.Exception ex)
            {
                return BadRequest("Falha ao cadastrar produto!");
            }
        }
    }
}
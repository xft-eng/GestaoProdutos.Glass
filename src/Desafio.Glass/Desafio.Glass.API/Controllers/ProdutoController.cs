using Desafio.Glass.Application.Interfaces;
using Desafio.Glass.Application.Model;
using Desafio.Glass.Application.Model.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Desafio.Glass.API.Controllers
{
    ///<Summary>
    /// ProdutoController
    ///</Summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        ///<Summary>
        /// Construtor
        ///</Summary>
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;

        }


        /// <summary>
        /// Listar Produto pelo código
        /// </summary>
        /// <param name="id">Identificador do código do registro.</param>
        /// <response code="200">Retorna um registro pelo código cadastrado na base.</response>  
        /// <response code="204">Nenhum produto encontrado na base.</response>
        /// <response code="400">Formato da requisição é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [Route("listarporid")]
        [ProducesResponseType(typeof(ProdutoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarPorIdAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var produto = await _produtoAppService.ListarPorIdAsync(id);

            if (produto == null)
                return NoContent();

            return Ok(produto);
        }


        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="vmProduto">Parâmetros que pode ser retornado na busca</param>
        /// <param name="pageSize">Opcionalmente usado para retornar uma quantidade específica de resultados</param>
        /// <param name="skip">Opcionalmente usado para retornar um salto para ignorar uma quantidade específica de itens do resultado.</param>
        /// <response code="200">Retorna uma coleção de registros filtrados pelos campos.</response>  
        /// <response code="204">Nenhum produto encontrado na base.</response>  
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [Route("listar")]
        [ProducesResponseType(typeof(IEnumerable<ProdutoModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarAsync([FromQuery] ConsultaProdutoModel vmProduto, int pageSize, int skip)
        {

            var produtos = await _produtoAppService.ListarProdutosComposeAsync(vmProduto, pageSize, skip);

            if (!produtos.Any())
                return NoContent();

            return Ok(produtos);
        }


        /// <summary>
        /// Inclui um novo registro a base de dados
        /// </summary>
        /// <param name="vmProduto">Dados do Produto</param>
        /// <response code="201">Retorna os dados do novo Produto.</response>  
        /// <response code="400">Formato da requisição é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [Route("incluir")]
        [ProducesResponseType(typeof(ProdutoModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IncluirAsync([FromBody] ProdutoModel vmProduto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _produtoAppService.IncluirAsync(vmProduto);

            return StatusCode((int)HttpStatusCode.Created, vmProduto);

        }


        /// <summary>
        /// Edita um produto da base
        /// </summary>
        /// <param name="vmProduto">Dados do Produto.</param>
        /// <response code="201">Retorna os dados do Produto.</response>  
        /// <response code="400">Formato da requisição é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut]
        [Route("editar")]
        [ProducesResponseType(typeof(ProdutoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditarAsync([FromBody] ProdutoModel vmProduto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            vmProduto.SituacaoProduto = true;
            await _produtoAppService.EditarAsync(vmProduto);

            return StatusCode((int)HttpStatusCode.Created, vmProduto);
        }




        /// <summary>
        /// Inativa um produto da base.
        /// </summary>
        /// <param name="id">Identificador do produto.</param>
        /// <response code="204">Produto Inativado.</response>  
        /// <response code="400">Formato da requisição é inválido.</response>
        /// <response code="404">Nenhum produto localizado</response>
        /// <response code="409">Produto já inativo na base.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete]
        [Route("inativar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InativarAsync(int id)
        {

            if (id <= 0)
                return BadRequest();

            var existeProduto = await _produtoAppService.ListarPorIdAsync(id);

            if (existeProduto == null)
                return NotFound();

            if (existeProduto.SituacaoProduto == false)
                return Conflict("Produto já está inativo na base!");


            existeProduto.SituacaoProduto = false;

            await _produtoAppService.EditarAsync(existeProduto);

            return NoContent();
        }

    }
}

using Desafio.Glass.API.Controllers;
using Desafio.Glass.Application.Interfaces;
using Desafio.Glass.Application.Model;
using Desafio.Glass.Application.Model.Input;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.Glass.Tests.Scenarios
{
    public class ProdutoControllerTest
    {
        private readonly IProdutoAppService _mockAppService;

        public ProdutoControllerTest() => _mockAppService = Substitute.For<IProdutoAppService>();

        #region ListarPorIdAsync

        [Fact]
        public async Task ListarPorIdAsync_ReturnsOk()
        {
            //Arrange
            var id = 1;

            _mockAppService.ListarPorIdAsync(id).ReturnsForAnyArgs(new ProdutoModel());

            ProdutoController controller = new ProdutoController(_mockAppService);

            //Act
            var result = await controller.ListarPorIdAsync(id);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ProdutoModel>(okResult.Value);
        }

        [Fact]
        public async Task ListarPorIdAsync_ReturnsNoContent()
        {
            //Arrange
            var id = 1;
            ProdutoModel produto = null;

            _mockAppService.ListarPorIdAsync(id).ReturnsForAnyArgs(produto);

            ProdutoController controller = new ProdutoController(_mockAppService);

            //Act
            var result = await controller.ListarPorIdAsync(id);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task ListarPorIdAsync_ReturnsBadRequest()
        {
            //Arrange
            var id = 0;
            ProdutoModel produto = null;

            _mockAppService.ListarPorIdAsync(id).ReturnsForAnyArgs(produto);

            ProdutoController controller = new ProdutoController(_mockAppService);

            //Act
            var result = await controller.ListarPorIdAsync(id);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        #endregion

        #region ListarAsync

        [Fact]
        public async Task ListarAsync_ReturnsOk()
        {
            //Arrange
            var vmConsulta = new ConsultaProdutoModel { SituacaoProduto = true };
            var pagesize = 20;
            var skip = 0;
            var produtos = new List<ProdutoModel>
            {
                new ProdutoModel()
            };

            _mockAppService.ListarProdutosComposeAsync(vmConsulta, pagesize, skip).ReturnsForAnyArgs(produtos);

            ProdutoController controller = new ProdutoController(_mockAppService);

            //Act
            var result = await controller.ListarAsync(vmConsulta, pagesize, skip);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProdutoModel>>(okResult.Value);
        }

        [Fact]
        public async Task ListarAsync_ReturnsNoContent()
        {
            //Arrange
            var vmConsulta = new ConsultaProdutoModel { SituacaoProduto = true };
            var pagesize = 20;
            var skip = 0;
            var produtos = new List<ProdutoModel>();

            _mockAppService.ListarProdutosComposeAsync(vmConsulta, pagesize, skip).ReturnsForAnyArgs(produtos);

            ProdutoController controller = new ProdutoController(_mockAppService);

            //Act
            var result = await controller.ListarAsync(vmConsulta, pagesize, skip);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        #endregion

        #region IncluirAsync

        [Fact]
        public async Task IncluirAsync_ReturnsCreated()
        {
            //Arrange
            var produto = new ProdutoModel();

            _mockAppService.IncluirAsync(produto).ReturnsForAnyArgs(produto);

            ProdutoController controller = new ProdutoController(_mockAppService);

            //Act
            var result = await controller.IncluirAsync(produto);

            //Assert
            var createdResult = Assert.IsType<ObjectResult>(result);
            Assert.IsType<ProdutoModel>(createdResult.Value);
        }

        [Fact]
        public async Task IncluirAsync_ReturnsBadRequest()
        {
            //Arrange
            ProdutoController controller = new ProdutoController(_mockAppService);
            controller.ModelState.AddModelError("DataFabricacao", "A Data de Fabricação que não pode ser maior ou igual a data de validade.");
            var produto = new ProdutoModel();
            //Act
            var result = await controller.IncluirAsync(produto);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        #endregion

        #region EditarAsync

        [Fact]
        public async Task EditarAsync_ReturnsCreated()
        {
            //Arrange
            var produto = new ProdutoModel();

            _mockAppService.EditarAsync(produto).ReturnsForAnyArgs(produto);

            ProdutoController controller = new ProdutoController(_mockAppService);

            //Act
            var result = await controller.EditarAsync(produto);

            //Assert
            var createdResult = Assert.IsType<ObjectResult>(result);
            Assert.IsType<ProdutoModel>(createdResult.Value);
        }

        [Fact]
        public async Task EditarAsync_ReturnsBadRequest()
        {
            //Arrange
            ProdutoController controller = new ProdutoController(_mockAppService);
            controller.ModelState.AddModelError("DataFabricacao", "A Data de Fabricação que não pode ser maior ou igual a data de validade.");
            var produto = new ProdutoModel();
            //Act
            var result = await controller.EditarAsync(produto);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
        #endregion

    }
}

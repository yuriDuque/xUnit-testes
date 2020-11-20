using APICompras.Controllers;
using APICompras.Models;
using APICompras.Services;
using APIComprasTest.ServicesFakes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace APIComprasTest.Tests
{
    // Arrange - È aqui que você normalmente prepara tudo para o teste, em outras palavras, prepara a cena para testar (criar os objetos e configurá-los conforme necessário)

    // Act - È onde o método que estamos testando é executado;

    //Assert - Esta é a parte final do teste em que comparamos o que esperamos que aconteça com o resultado real da execução do método de teste;

    public class ComprasControllerTest
    {
        ComprasController _controller;
        ICompraService _service;
        public ComprasControllerTest()
        {
            _service = new CompraServiceFake();
            _controller = new ComprasController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act 
            var okResult = _controller.Get().Result as OkObjectResult;

            //Assert  
            var items = Assert.IsType<List<CompraItem>>(okResult.Value);

            //bool result = items.Any(x => x.Nome == "Tablet SamSung 7");
            //Assert.True(result);

            Assert.Equal(3, items.Count); 
        }
    }
}

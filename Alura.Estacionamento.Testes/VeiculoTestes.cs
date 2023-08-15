using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Padr�o AAA
            //Arrange - Prepara��o do cen�rio (inst�ncia do objeto, inicilizar vari�veis)
            var veiculo = new Veiculo();
            //Act - Literalmente o teste
            veiculo.Acelerar(10);
            //Assert - Resultado obtido da execu��o do m�todo de teste
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaPlacaVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal("AAA-1234", veiculo.Placa);
        }
    }
}
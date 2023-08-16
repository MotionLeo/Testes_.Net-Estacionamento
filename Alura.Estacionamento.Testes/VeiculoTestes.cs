using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName = "Teste de acelera��o")] //Displayname da um nome para o teste, n�o utilizando assim o nome do m�todo
        [Trait("Funcionalidade", "Acelerar")] //Trait da um nome para um grupo de teste e um nome para esse teste dentro do grupo
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Padr�o AAA
            //Arrange - Prepara��o do cen�rio (inst�ncia do objeto, inicilizar vari�veis)
            var veiculo = new Veiculo();
            //Act - O met�do/fun��o que ser� testado
            veiculo.Acelerar(10);
            //Assert - Resultado obtido da execu��o do m�todo de teste
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste de freio")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
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
            veiculo.Placa = "AAA-1234";
            //Assert
            Assert.NotNull(veiculo.Placa);
        }

        [Fact(DisplayName = "Teste skipado", Skip = "Teste ainda n�o implementado. Ignorar")] //Skip usado para ignorar o teste, n�o executando ele durante os testes
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            var carro = new Veiculo();
            carro.Proprietario = "Frederico";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Cor = "Vermelho";
            carro.Modelo = "Palio";
            carro.Placa = "PQR-1472";

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Ficha do Ve�culo:", dados);
        }
    }
}
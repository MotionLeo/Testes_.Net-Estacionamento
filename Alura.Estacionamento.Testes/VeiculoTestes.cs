using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName = "Teste de aceleração")] //Displayname da um nome para o teste, não utilizando assim o nome do método
        [Trait("Funcionalidade", "Acelerar")] //Trait da um nome para um grupo de teste e um nome para esse teste dentro do grupo
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Padrão AAA
            //Arrange - Preparação do cenário (instância do objeto, inicilizar variáveis)
            var veiculo = new Veiculo();
            //Act - O metódo/função que será testado
            veiculo.Acelerar(10);
            //Assert - Resultado obtido da execução do método de teste
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

        [Fact(DisplayName = "Teste skipado", Skip = "Teste ainda não implementado. Ignorar")] //Skip usado para ignorar o teste, não executando ele durante os testes
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
            Assert.Contains("Ficha do Veículo:", dados);
        }
    }
}
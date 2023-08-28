using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;
        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste) 
        {
            veiculo = new Veiculo();
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado");
        }


        [Fact(DisplayName = "Teste de aceleração")] //Displayname da um nome para o teste, não utilizando assim o nome do método
        [Trait("Funcionalidade", "Acelerar")] //Trait da um nome para um grupo de teste e um nome para esse teste dentro do grupo
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Padrão AAA
            //Arrange - Preparação do cenário (instância do objeto, inicilizar variáveis)
            //var veiculo = new Veiculo();
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
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaPlacaVeiculo()
        {
            //Arrange
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
            veiculo.Proprietario = "Frederico";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Palio";
            veiculo.Placa = "PQR-1472";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
            );

        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF8888";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
                );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        [Fact]
        public void TestaUltimosCaracteresPlacaVeicuiloComoNumeros()
        {
            //Arrange
            string placaFormatoErrado = "ABC-987S";

            //Assert
            Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placaFormatoErrado
                );
        }
        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}
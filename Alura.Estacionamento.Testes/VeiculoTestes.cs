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


        [Fact(DisplayName = "Teste de acelera��o")] //Displayname da um nome para o teste, n�o utilizando assim o nome do m�todo
        [Trait("Funcionalidade", "Acelerar")] //Trait da um nome para um grupo de teste e um nome para esse teste dentro do grupo
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Padr�o AAA
            //Arrange - Prepara��o do cen�rio (inst�ncia do objeto, inicilizar vari�veis)
            //var veiculo = new Veiculo();
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

        [Fact(DisplayName = "Teste skipado", Skip = "Teste ainda n�o implementado. Ignorar")] //Skip usado para ignorar o teste, n�o executando ele durante os testes
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
            Assert.Contains("Ficha do Ve�culo:", dados);
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
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
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
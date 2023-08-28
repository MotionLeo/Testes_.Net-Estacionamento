using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste : IDisposable
    {

        private Patio estacionamento;
        private Veiculo veiculo;
        private Operador operador;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            estacionamento = new Patio();
            veiculo = new Veiculo();
            operador = new Operador();
            operador.Nome = "Ricardo Silva";
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado");
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            veiculo.Proprietario = "Leonardo";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Amarelo";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "AAA-1234";

            estacionamento.OperadorPatio = operador;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Leonardo D", "ABC-1234", "Amarelo", "Fusca")]
        [InlineData("José D", "DEF-5678", "Azul", "Gol")]
        [InlineData("Maria D", "GHI-9012", "Vermelho", "Fusion")]
        [InlineData("Pedro D", "JKL-3456", "Cinza", "Celta")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo.Proprietario= proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.OperadorPatio = operador;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();
            //Assert
            Assert.Equal(2,faturamento);
        }

        [Theory]
        [InlineData("Leonardo D", "ABC-1234", "Amarelo", "Fusca")]
        [InlineData("José D", "DEF-5678", "Azul", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.OperadorPatio = operador;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket); ;

            //Assert
            Assert.Contains("### Ticket Estacionamneto Alura ###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosDoVeiculo()
        {
            //Arrange
            estacionamento.OperadorPatio = operador;

            veiculo.Proprietario = "Alberto";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Cinza";
            veiculo.Modelo = "Civic";
            veiculo.Placa = "MNO-7890";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Alberto";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Preto"; //Alterado
            veiculoAlterado.Modelo = "Civic";
            veiculoAlterado.Placa = "MNO-7890";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}

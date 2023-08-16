using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste
    {
        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Leonardo";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Amarelo";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "AAA-1234";

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
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario= proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

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
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosDoVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
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
    }
}

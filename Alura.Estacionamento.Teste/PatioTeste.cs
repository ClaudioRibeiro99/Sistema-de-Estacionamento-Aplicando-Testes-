using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Teste
{
    public class PatioTeste
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Joao Ribeiro";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Prata";
            veiculo.Modelo = "Celta";
            veiculo.Placa = "AAA-2022";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Maria Santos", "PPP-2222", "Preto", "Gol")]
        [InlineData("Gabriel Santana", "GGG-3333", "Azul", "Onix")]
        [InlineData("Paulo Henrique", "ZZZ-1212", "Vermelho", "Palio")]
        [InlineData("João Paulo", "YYY-6231", "Prata", "Logan")]

        public void ValidaFaturamentoComVariosVeiculos(string proprietario,
                                                        string placa,
                                                        string cor,
                                                        string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Maria Santos", "PPP-2222", "Preto", "Gol")]
        public void LocalizaVeiculoNoPatio(string proprietario,
                                            string placa,
                                            string cor,
                                            string modelo)
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
    }
}

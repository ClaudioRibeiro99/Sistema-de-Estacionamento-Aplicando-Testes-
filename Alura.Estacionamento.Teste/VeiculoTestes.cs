using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Teste
{
    public class VeiculoTestes
    {
        [Fact(DisplayName ="Teste n. 1")]
        [Trait("Funcionalidade","Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n. 2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n. 3", Skip ="Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            var carro = new Veiculo();
            carro.Proprietario = "Claudio Ribeiro";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "DSQ-8304";
            carro.Cor = "Branco";
            carro.Modelo = "Corsa";

            //Act
            string dados = carro.ToString();

            //Assent
            Assert.Contains("Ficha do veículo", dados);
        }
    }
}
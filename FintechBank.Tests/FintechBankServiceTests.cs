using FintechBank.App;

namespace FintechBank.Tests;

public class FintechBankServiceTests
{
    [Theory]
    [InlineData(6000, false, 0.00)]
    [InlineData(2000, false, 12.50)]
    [InlineData(500, false, 25.00)]
    [InlineData(500, true, 0.00)]
    public void DeveCalcularTaxaManutencaoCorretamente(
        decimal saldo,
        bool clienteEspecial,
        decimal taxaEsperada)
    {
        var service = new ContaCorrenteService();

        var resultado = service.CalcularTaxaManutencao(
            saldo, clienteEspecial);

        Assert.Equal(taxaEsperada, resultado);
    }

    [Theory]
    [InlineData(1000, 200, 500, true)]
    [InlineData(1000, 200, 1200, true)]
    [InlineData(1000, 200, 1201, false)]
    public void DeveValidarSaqueCorretamente(
        decimal saldo,
        decimal limite,
        decimal valorSaque,
        bool esperado)
    {
        var service = new ContaCorrenteService();

        var resultado = service.PodeRealizarSaque(
            saldo, limite, valorSaque);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(1000, 10, 700, 105)]
    [InlineData(1000, 10, 500, 112)]
    [InlineData(1000, 10, 400, 120)]
    public void DeveCalcularValorParcelaCorretamente(
        decimal valorTotal,
        int parcelas,
        int scoreCredito,
        decimal parcelaEsperada)
    {
        var service = new EmprestimoService();

        var resultado = service.CalcularValorParcela(
            valorTotal, parcelas, scoreCredito);

        Assert.Equal(parcelaEsperada, resultado);
    }

    [Theory]
    [InlineData(3000, 900, true)]
    [InlineData(3000, 901, false)]
    [InlineData(3000, 600, true)]
    public void DeveValidarAprovacaoEmprestimoCorretamente(
        decimal rendaMensal,
        decimal valorParcela,
        bool esperado)
    {
        var service = new EmprestimoService();

        var resultado = service.AprovarEmprestimo(
            rendaMensal, valorParcela);

        Assert.Equal(esperado, resultado);
    }
}
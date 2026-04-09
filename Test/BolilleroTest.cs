using Dominio;

namespace Test;

public class BolilleroTest
{
    private Bolillero bolillero;

    public BolilleroTest()
    {
        bolillero = new Bolillero(10);
        bolillero.SetAzar(new Primero());
    }

    [Fact]
    public void SacarBolilla()
    {
        var bolilla = bolillero.SacarBolilla();

        Assert.Equal(0, bolilla);
        Assert.Equal(9, bolillero.BolillasAdentro());
        Assert.Equal(1, bolillero.BolillasAfuera());
    }

    [Fact]
    public void ReIngresar()
    {
        bolillero.SacarBolilla();
        bolillero.Reingresar();

        Assert.Equal(10, bolillero.BolillasAdentro());
        Assert.Equal(0, bolillero.BolillasAfuera());
    }

    [Fact]
    public void JugarGana()
    {
        var jugada = new List<int> { 0, 1, 2, 3 };

        var resultado = bolillero.Jugar(jugada);

        Assert.True(resultado);
    }

    [Fact]
    public void JugarPierde()
    {
        var jugada = new List<int> { 4, 2, 1 };

        var resultado = bolillero.Jugar(jugada);

        Assert.False(resultado);
    }

    [Fact]
    public void GanarNVeces()
    {
        var jugada = new List<int> { 0, 1 };

        var ganadas = bolillero.JugarNVeces(jugada, 1);

        Assert.Equal(1, ganadas);
    }
}
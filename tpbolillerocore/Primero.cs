namespace Dominio;

public class Primero : IAzar
{
    private int actual = 0;

    public int Sacar(int max)
    {
        return actual++;
    }
}
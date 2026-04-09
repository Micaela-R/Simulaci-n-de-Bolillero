namespace Dominio;

public class AzarRandom : IAzar
{
    private Random random = new Random();

    public int Sacar(int max)
    {
        return random.Next(0, max);
    }
}
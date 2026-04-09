using System.Threading.Tasks;

namespace Dominio;

public class Bolillero
{
    private List<int> adentro;
    private List<int> afuera;
    private IAzar azar;

    public Bolillero(int cantidad)
    {
        adentro = new List<int>();
        afuera = new List<int>();

        for (int i = 0; i < cantidad; i++)
            adentro.Add(i);
    }

    public void SetAzar(IAzar azar)
    {
        this.azar = azar;
    }

    public int SacarBolilla()
    {
        int indice = azar.Sacar(adentro.Count);
        int bolilla = adentro[indice];

        adentro.RemoveAt(indice);
        afuera.Add(bolilla);

        return bolilla;
    }

    public void Reingresar()
    {
        adentro.AddRange(afuera);
        afuera.Clear();
    }

    public bool Jugar(List<int> jugada)
    {
        Reingresar();

        foreach (var num in jugada)
        {
            int sacada = SacarBolilla();

            if (sacada != num)
                return false;
        }

        return true;
    }

    public int JugarNVeces(List<int> jugada, int veces)
    {
        List<Task<bool>> tareas = new List<Task<bool>>();

        for (int i = 0; i < veces; i++)
        {
            var tarea = Task.Run(() =>
            {
                return Jugar(jugada);
            });

            tareas.Add(tarea);
        }

        Task.WaitAll(tareas.ToArray());

        int ganadas = 0;

        foreach (var t in tareas)
        {
            if (t.Result)
                ganadas++;
        }

        return ganadas;
    }

    public int BolillasAdentro()
    {
        return adentro.Count;
    }

    public int BolillasAfuera()
    {
        return afuera.Count;
    }
}
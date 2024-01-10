namespace Remy.Tempo;

public class GameLoop
{
    public bool Loop { get; set; }

    Tempo _tempo = new Tempo();

    public GameLoop() {}

    public void Iniciar()
    {
        Loop = true;

        int i = 0;
        while (i <= 360)
        {
            //Logs.LogFile.WriteLine);
            //string[] args = Logs.LogFile.WriteLine).Split(" ");

            //Comandos.Executar(args);


            _tempo.Atualizar();

            Logs.LogFile.WriteLine("----------TEMPO----------");
            Logs.LogFile.WriteLine("[Tempo real]: {0}", _tempo.TempoRealAtual);
            Logs.LogFile.WriteLine("[Quadro em tempo real]: {0}", _tempo.QuadroTempoReal);
            Logs.LogFile.WriteLine("[Ultimo tempo real]: {0}", _tempo._ultimotemporeal);
            Logs.LogFile.WriteLine("[FPS]: {0}", _tempo.CalcFpsAvg());
            Logs.LogFile.WriteLine("[Media de quadros]: {0}", _tempo.RealFrameTimeAvg);


            Remy.Render.Vector2 DimMapa = new Remy.Render.Vector2(20, 20);

            int[,] Mapa = new int[DimMapa.x, DimMapa.y];
            for(int x = 0; x < DimMapa.x; x++)
            {
                for(int y = 0; y < DimMapa.y; y++)
                {
                    Mapa[x, y] = new Random().Next(1,32);
                }
            }

            // for(int x = 0; x < DimMapa.x; x++)
            // {
            //     for(int y = 0; y < DimMapa.y; y++)
            //     {
            //         Logs.LogFile.WriteLine("[x: {0}, y: {1}]: {2}", x, y, Mapa[x, y]);
            //     }
            // }


            Thread.Sleep(TimeSpan.FromMilliseconds(1000/_tempo.QuadroPorSegundo));

            i++;
        }
    }
}
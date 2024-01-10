using System.Diagnostics;

namespace Remy.Tempo
{
    public class Tempo
    {
        private Stopwatch _temporeal = new Stopwatch();
        private readonly long[] _realFrameTimes = new long[NumQuadros];
        private const int NumQuadros = 30;
        public int QuadroPorSegundo = NumQuadros;
        private int _frameIdx;
        public TimeSpan _ultimotemporeal;

        public TimeSpan QuadroTempoReal { get; private set; }
        
        public Tempo()
        {
            _temporeal.Start();
        }

        public TimeSpan TempoRealAtual;
        public TimeSpan RealFrameTimeAvg => TimeSpan.FromTicks((long)_realFrameTimes.Average());

        public void Atualizar()
        {
            TempoRealAtual = _temporeal.Elapsed;
            QuadroTempoReal = TempoRealAtual - _ultimotemporeal;
            _ultimotemporeal = TempoRealAtual;

            _frameIdx = (1 + _frameIdx) % _realFrameTimes.Length;
            _realFrameTimes[_frameIdx] = QuadroTempoReal.Ticks;
        }

        public bool FrameUpdate => _frameIdx == (NumQuadros - 1);

        public double CalcFpsAvg()
        {
            return 1 / (_realFrameTimes.Average() / TimeSpan.TicksPerSecond);
        }
    }
}
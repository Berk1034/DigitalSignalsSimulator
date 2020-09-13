using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalsSimulator.Signals
{
    public class TriangleWaveSignal : Signal
    {
        public override List<double> GenerateSignal()
        {
            List<double> generatedSignal = new List<double>();
            for (int n = 0; n < SampleRate; n++)
            {
                var result = 2 * Amplitude / Math.PI * Math.Asin(Math.Sin(2 * Math.PI * Frequency * n / SampleRate));
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }
    }
}

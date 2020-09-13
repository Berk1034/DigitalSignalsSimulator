using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalsSimulator.Signals
{
    public class NoiseSignal : Signal
    {
        private Random random = new Random();

        public override List<double> GenerateSignal()
        {
            List<double> generatedSignal = new List<double>();

            for (int n = 0; n < SampleRate; n++)
            {
                var result = random.NextDouble() * 2 * Amplitude - Amplitude;
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }
    }
}

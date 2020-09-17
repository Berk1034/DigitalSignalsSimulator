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

        public override double GenerateSample()
        {
            return random.NextDouble() * 2 * Amplitude - Amplitude;
        }
    }
}

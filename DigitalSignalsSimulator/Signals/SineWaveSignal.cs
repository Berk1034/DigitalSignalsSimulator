using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalsSimulator.Signals
{
    public class SineWaveSignal : Signal
    {
        public override double GenerateSample()
        {
            FiAngle += 2 * Math.PI * Frequency * (1 + (FM?.GenerateSample() ?? 0)) / SampleRate;
            return Amplitude * Math.Sin(FiAngle);
        }
    }
}

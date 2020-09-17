using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalsSimulator.Signals
{
    public class SawtoothWaveSignal : Signal
    {
        public override double GenerateSample()
        {
            FiAngle += Math.PI * Frequency * (1 + (FM?.GenerateSample() ?? 0)) / SampleRate;
            return -2 * Amplitude / Math.PI * Math.Atan(1.0 / Math.Tan(FiAngle));
        }
    }
}

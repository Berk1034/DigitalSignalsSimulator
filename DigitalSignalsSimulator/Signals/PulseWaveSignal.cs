using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalsSimulator.Signals
{
    public class PulseWaveSignal : Signal
    {
        public double DutyCycle { get; set; }

        public override double GenerateSample()
        {
            FiAngle += 2 * Math.PI * Frequency * (1 + (FM?.GenerateSample() ?? 0)) / SampleRate;
            var cycle = 2 * Math.PI;
            return (FiAngle % cycle) / cycle > DutyCycle ? 0.0 : Amplitude;
        }
    }
}

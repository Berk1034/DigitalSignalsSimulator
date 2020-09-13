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

        public override List<double> GenerateSignal()
        {
            List<double> generatedSignal = new List<double>();

            for (int n = 0; n < SampleRate; n++)
            {
                var result = ((double)n / SampleRate % (1.0 / Frequency) * Frequency) > DutyCycle ? 0.0 : Amplitude;
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }
    }
}

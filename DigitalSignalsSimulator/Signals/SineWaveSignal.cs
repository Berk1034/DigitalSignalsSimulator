using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalsSimulator.Signals
{
    public class SineWaveSignal : Signal
    {
        public double FiAngle { get; set; }

        public override List<double> GenerateSignal()
        {
            List<double> generatedSignal = new List<double>();
            for (int n = 0; n < SampleRate; n++)
            {
                var result = Amplitude * Math.Sin(2 * Math.PI * Frequency * n / SampleRate + FiAngle);
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }
    }
}

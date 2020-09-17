using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalsSimulator.Signals
{
    public abstract class Signal 
    {
        public Signal AM;
        public Signal FM;
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        public double FiAngle { get; set; } = default;
        public int SampleRate { get; set; } = 44100 * 10;

        public abstract double GenerateSample();
        public List<double> GenerateSignal()
        {
            List<double> generatedSignal = new List<double>();

            //Amplitude = Math.Round(Amplitude / (double)Int16.MaxValue, 3);

            for (int n = 0; n < SampleRate; n++)
            {
                var result = GenerateSample() * (1 + (AM?.GenerateSample() ?? 0));
                generatedSignal.Add(result);
            }

            FiAngle = default;
            if (AM != null)
            {
                AM.FiAngle = default;
            }
            if (FM != null)
            {
                FM.FiAngle = default;
            }

            return generatedSignal;
        }
    }
}

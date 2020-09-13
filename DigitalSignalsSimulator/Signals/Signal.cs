using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalsSimulator.Signals
{
    public abstract class Signal 
    {
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        public int SampleRate { get; set; } = 44100;

        public abstract List<double> GenerateSignal();
    }
}

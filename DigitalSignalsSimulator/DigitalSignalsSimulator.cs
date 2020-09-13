using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalSignalsSimulator.Signals;
using DigitalSignalsSimulator.FileWriters;

namespace DigitalSignalsSimulator
{
    public partial class DigitalSignalsSimulator : Form
    {
        private Signal currentSignal;
        private List<double> generatedSignal = new List<double>();
        private List<List<double>> polyHarmonicsSignal = new List<List<double>>();
        private const string PATH = "Result.wav";
        private bool createPoly = false;
        private int sampleRate = 44100;

        public DigitalSignalsSimulator()
        {
            InitializeComponent();
            comboBoxWave.SelectedIndex = 0;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!createPoly)
            {
                double A = Convert.ToDouble(textBoxA.Text);
                double f = Convert.ToDouble(textBoxF.Text);
                double Fi = Convert.ToDouble(textBoxFi.Text);
                double D = Convert.ToDouble(textBoxD.Text);

                switch (comboBoxWave.SelectedIndex)
                {
                    case 0:
                        currentSignal = new SineWaveSignal { Amplitude = A, Frequency = f, FiAngle = Fi };
                        break;
                    case 1:
                        currentSignal = new PulseWaveSignal { Amplitude = A, Frequency = f, DutyCycle = D };
                        break;
                    case 2:
                        currentSignal = new TriangleWaveSignal { Amplitude = A, Frequency = f };
                        break;
                    case 3:
                        currentSignal = new SawtoothWaveSignal { Amplitude = A, Frequency = f };
                        break;
                    case 4:
                        currentSignal = new NoiseSignal { Amplitude = A, Frequency = f };
                        break;
                }

                generatedSignal = currentSignal.GenerateSignal();
            }
            else
            {
                generatedSignal = new List<double>(polyHarmonicsSignal[0]);
                for (int i = 1; i < polyHarmonicsSignal.Count; i++)
                {
                    for (int j = 0; j < generatedSignal.Count; j++)
                    {
                        generatedSignal[j] += polyHarmonicsSignal[i][j];
                    }
                }

                createPoly = false;
            }

            var wavFileWriter = new WavFileWriter(new FileStream(PATH, FileMode.Create), sampleRate, 1000000, 1);
            wavFileWriter.WriteAll(generatedSignal);
        }

        private void buttonAddPoly_Click(object sender, EventArgs e)
        {
            createPoly = true;

            double A = Convert.ToDouble(textBoxA.Text);
            double f = Convert.ToDouble(textBoxF.Text);
            double Fi = Convert.ToDouble(textBoxFi.Text);
            double D = Convert.ToDouble(textBoxD.Text);

            switch (comboBoxWave.SelectedIndex)
            {
                case 0:
                    currentSignal = new SineWaveSignal { Amplitude = A, Frequency = f, FiAngle = Fi };
                    break;
                case 1:
                    currentSignal = new PulseWaveSignal { Amplitude = A, Frequency = f, DutyCycle = D };
                    break;
                case 2:
                    currentSignal = new TriangleWaveSignal { Amplitude = A, Frequency = f };
                    break;
                case 3:
                    currentSignal = new SawtoothWaveSignal { Amplitude = A, Frequency = f };
                    break;
                case 4:
                    currentSignal = new NoiseSignal { Amplitude = A, Frequency = f };
                    break;
            }

            generatedSignal = currentSignal.GenerateSignal();

            polyHarmonicsSignal.Add(generatedSignal);
        }

        private void buttonClearPoly_Click(object sender, EventArgs e)
        {
            polyHarmonicsSignal.Clear();
            createPoly = false;
        }
    }
}

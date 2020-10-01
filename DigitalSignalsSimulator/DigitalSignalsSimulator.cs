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
        private Signal modulationSignal;
        private List<double> generatedSignal = new List<double>();
        private List<Signal> resultSignal = new List<Signal>();
        private List<List<double>> polyHarmonicsSignal = new List<List<double>>();
        private const string PATH = "Result.wav";
        private bool createPoly = false;
        private int sampleRate = 44100;
        private int soundLength = 10;

        public DigitalSignalsSimulator()
        {
            InitializeComponent();
            comboBoxWave.SelectedIndex = 0;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!createPoly)
            {
                var inputValues = ProcessInput();
                currentSignal = CreateProperSignal(comboBoxWave.SelectedIndex, inputValues.Item1, inputValues.Item2, inputValues.Item3);

                generatedSignal = currentSignal.GenerateSignal();
            }
            else
            {
                
                generatedSignal = resultSignal[0].GenerateSignal();
                for (int i = 1; i < resultSignal.Count; i++)
                {
                    var getSignal = resultSignal[i].GenerateSignal();
                    for (int j = 0; j < getSignal.Count; j++)
                    {
                        generatedSignal[j] += getSignal[j];
                    }
                }
                
                /*
                generatedSignal = new List<double>(polyHarmonicsSignal[0]);
                for (int i = 1; i < polyHarmonicsSignal.Count; i++)
                {
                    for (int j = 0; j < generatedSignal.Count; j++)
                    {
                        generatedSignal[j] += polyHarmonicsSignal[i][j];
                    }
                }
                */
                createPoly = false;
            }

            var wavFileWriter = new WavFileWriter(new FileStream(PATH, FileMode.Create), sampleRate, 1000000, 1);
            wavFileWriter.WriteAll(generatedSignal, 10);
        }

        private void buttonAddPoly_Click(object sender, EventArgs e)
        {
            createPoly = true;

            var inputValues = ProcessInput();
            currentSignal = CreateProperSignal(comboBoxWave.SelectedIndex, inputValues.Item1, inputValues.Item2, inputValues.Item3);

            resultSignal.Add(currentSignal);

            generatedSignal = currentSignal.GenerateSignal();

            polyHarmonicsSignal.Add(generatedSignal);
        }

        private void buttonClearPoly_Click(object sender, EventArgs e)
        {
            resultSignal.Clear();
            polyHarmonicsSignal.Clear();
            createPoly = false;
        }

        private void buttonModulateAmplitude_Click(object sender, EventArgs e)
        {
            if (generatedSignal.Count == 0)
            {
                MessageBox.Show("Generate signal first!");
            }
            else
            {
                var inputValues = ProcessInput();
                modulationSignal = CreateProperSignal(comboBoxWave.SelectedIndex, inputValues.Item1, inputValues.Item2, inputValues.Item3);
                currentSignal.AM = modulationSignal;

                generatedSignal = currentSignal.GenerateSignal();
                var wavFileWriter = new WavFileWriter(new FileStream(PATH, FileMode.Create), sampleRate, 1000000, 1);
                wavFileWriter.WriteAll(generatedSignal, soundLength);
            }
        }

        private void buttonModulateFrequency_Click(object sender, EventArgs e)
        {
            if (generatedSignal.Count == 0)
            {
                MessageBox.Show("Generate signal first!");
            }
            else
            {
                var inputValues = ProcessInput();
                modulationSignal = CreateProperSignal(comboBoxWave.SelectedIndex, inputValues.Item1, inputValues.Item2, inputValues.Item3);
                currentSignal.FM = modulationSignal;

                generatedSignal = currentSignal.GenerateSignal();
                var wavFileWriter = new WavFileWriter(new FileStream(PATH, FileMode.Create), sampleRate, 1000000, 1);
                wavFileWriter.WriteAll(generatedSignal, soundLength);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            generatedSignal.Clear();
        }

        private Signal CreateProperSignal(int index, double A, double f, double D)
        {
            switch (index)
            {
                case 0:
                    return new SineWaveSignal { Amplitude = A, Frequency = f };
                case 1:
                    return new PulseWaveSignal { Amplitude = A, Frequency = f, DutyCycle = D };
                case 2:
                    return new TriangleWaveSignal { Amplitude = A, Frequency = f };
                case 3:
                    return new SawtoothWaveSignal { Amplitude = A, Frequency = f };
                case 4:
                    return new NoiseSignal { Amplitude = A, Frequency = f };
                default:
                    return default;
            }
        }

        private Tuple<double, double, double> ProcessInput()
        {
            double A = Math.Round(Convert.ToDouble(textBoxA.Text) / (double)Int16.MaxValue, 3);
            double f = Convert.ToDouble(textBoxF.Text);
            double D = Convert.ToDouble(textBoxD.Text);

            return new Tuple<double, double, double>(A, f, D);
        }
    }
}

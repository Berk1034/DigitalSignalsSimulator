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

namespace DigitalSignalsSimulator
{
    public partial class DigitalSignalsSimulator : Form
    {
        private List<double> generatedSignal = new List<double>();
        private List<List<double>> polyHarmonicsSignal = new List<List<double>>();
        private const string PATH = "Result.wav";
        private bool createPoly = false;

        public DigitalSignalsSimulator()
        {
            InitializeComponent();
            comboBoxN.SelectedIndex = 0;
            comboBoxWave.SelectedIndex = 0;
        }

        public List<double> GenerateSineWave(double A, double f, double Fi, int N)
        {
            List<double> generatedSignal = new List<double>();
            for (int n = 0; n < N; n++)
            {
                var result = A * Math.Sin(2 * Math.PI * f * n / N + Fi);
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public List<double> GeneratePulseWave(double A, double f, double D, int N)
        {
            List<double> generatedSignal = new List<double>();
            for (int n = 0; n < N; n++)
            {
                //var result = D * f + 2 * Math.Sin(Math.PI * D * f) * Math.Cos(2 * Math.PI * n * f * n / N);
                //var result = ((n / N) % (1 / f)) * f < D ? A : 0;
                var result = Math.Sign(Math.Sin(2 * Math.PI * f * n / N)) < D ? A : 0;

                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public List<double> GenerateTriangleWave(double A, double f, int N)
        {
            List<double> generatedSignal = new List<double>();
            for (int n = 0; n < N; n++)
            {
                var result = 2 * A / Math.PI * Math.Asin(Math.Sin(2 * Math.PI * f * n / N));
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public List<double> GenerateSawtoothWave(double A, double f, int N)
        {
            List<double> generatedSignal = new List<double>();
            for (int n = 0; n < N; n++)
            {
                var result = - 2 * A / Math.PI * Math.Atan(1.0 / Math.Tan(Math.PI * f * n / N));
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public List<double> GenerateNoise(double A, int N)
        {
            List<double> generatedSignal = new List<double>();

            Random random = new Random();

            for (int n = 0; n < N; n++)
            {
                var result = random.NextDouble() * 2 * A - A;
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public void CreateWavFile(List<double> data)
        {
            int subChunk1Size = 16;
            short audioFormat = 1;
            short bitsPerSample = 16;
            short numChannels = 2;
            int sampleRate = 22050; //44100
            int byteRate = sampleRate * numChannels * (bitsPerSample / 8);
            int numSamples = 1000000;
            short blockAlign = (short)(numChannels * (bitsPerSample / 8));
            int subChunk2Size = numSamples * numChannels * (bitsPerSample / 8);
            int chunkSize = 4 + (8 + subChunk1Size) + (8 + subChunk2Size);

            using (BinaryWriter bw = new BinaryWriter(new FileStream(PATH, FileMode.Create)))
            {
                bw.Write(Encoding.ASCII.GetBytes("RIFF"));
                bw.Write(chunkSize);
                bw.Write(Encoding.ASCII.GetBytes("WAVE"));
                bw.Write(Encoding.ASCII.GetBytes("fmt"));
                bw.Write((byte)32);
                bw.Write(subChunk1Size);
                bw.Write(audioFormat);
                bw.Write(numChannels);
                bw.Write(sampleRate);
                bw.Write(byteRate);
                bw.Write(blockAlign);
                bw.Write(bitsPerSample);
                bw.Write(Encoding.ASCII.GetBytes("data"));
                bw.Write(subChunk2Size);

                for (int i = 0; i < numSamples; i++)
                {
                    //var output = (byte)Math.Round(generatedSignal[i % generatedSignal.Count]);
                    bw.Write((byte)Math.Round(data[i % generatedSignal.Count]));
                }
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!createPoly)
            {
                double A = Convert.ToDouble(textBoxA.Text);
                double f = Convert.ToDouble(textBoxF.Text);
                double Fi = Convert.ToDouble(textBoxFi.Text);
                double D = Convert.ToDouble(textBoxD.Text);
                int N = Convert.ToInt32(comboBoxN.SelectedItem);

                switch (comboBoxWave.SelectedIndex)
                {
                    case 0:
                        generatedSignal = GenerateSineWave(A, f, Fi, N);
                        break;
                    case 1:
                        generatedSignal = GeneratePulseWave(A, f, D, N);
                        break;
                    case 2:
                        generatedSignal = GenerateTriangleWave(A, f, N);
                        break;
                    case 3:
                        generatedSignal = GenerateSawtoothWave(A, f, N);
                        break;
                    case 4:
                        generatedSignal = GenerateNoise(A, N);
                        break;
                }
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

            CreateWavFile(generatedSignal);
        }

        private void buttonAddPoly_Click(object sender, EventArgs e)
        {
            createPoly = true;

            double A = Convert.ToDouble(textBoxA.Text);
            double f = Convert.ToDouble(textBoxF.Text);
            double Fi = Convert.ToDouble(textBoxFi.Text);
            double D = Convert.ToDouble(textBoxD.Text);
            int N = Convert.ToInt32(comboBoxN.SelectedItem);
            switch (comboBoxWave.SelectedIndex)
            {
                case 0:
                    polyHarmonicsSignal.Add(GenerateSineWave(A, f, Fi, N));
                    break;
                case 1:
                    polyHarmonicsSignal.Add(GeneratePulseWave(A, f, D, N));
                    break;
                case 2:
                    polyHarmonicsSignal.Add(GenerateTriangleWave(A, f, N));
                    break;
                case 3:
                    polyHarmonicsSignal.Add(GenerateSawtoothWave(A, f, N));
                    break;
                case 4:
                    polyHarmonicsSignal.Add(GenerateNoise(A, N));
                    break;
            }
        }

        private void buttonClearPoly_Click(object sender, EventArgs e)
        {
            polyHarmonicsSignal.Clear();
            createPoly = false;
        }
    }
}

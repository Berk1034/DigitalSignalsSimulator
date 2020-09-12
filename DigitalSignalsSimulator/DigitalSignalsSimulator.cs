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
        private const string PATH = "Result.wav";

        public DigitalSignalsSimulator()
        {
            InitializeComponent();
            comboBoxN.SelectedIndex = 0;
            comboBoxWave.SelectedIndex = 0;
        }

        public void GenerateSineWave(double A, double f, double Fi, int N)
        {
            generatedSignal.Clear();
            for (int n = 0; n < N; n++)
            {
                var result = A * Math.Sin(2 * Math.PI * f * n / N + Fi);
                generatedSignal.Add(result);
            }
        }

        public void GeneratePulseWave(double A, double f, double D, int N)
        {
            generatedSignal.Clear();
            for (int n = 0; n < N; n++)
            {
                //var result = D * f + 2 * Math.Sin(Math.PI * D * f) * Math.Cos(2 * Math.PI * n * f * n / N);
                //var result = ((n / N) % (1 / f)) * f < D ? A : -A;
                var result = Math.Sign(Math.Sin(2 * Math.PI * f * n / N)) < D ? A : -A;

                generatedSignal.Add(result);
            }
        }

        public void GenerateTriangleWave(double A, double f, int N)
        {
            generatedSignal.Clear();
            for (int n = 0; n < N; n++)
            {
                var result = 2 * A / Math.PI * Math.Asin(Math.Sin(2 * Math.PI * f * n / N));
                generatedSignal.Add(result);
            }
        }

        public void GenerateSawtoothWave(double A, double f, int N)
        {
            generatedSignal.Clear();
            for (int n = 0; n < N; n++)
            {
                var result = - 2 * A / Math.PI * Math.Atan(1.0 / Math.Tan(Math.PI * f * n / N));
                generatedSignal.Add(result);
            }
        }

        public void GenerateNoise(double A, int N)
        {
            generatedSignal.Clear();

            Random random = new Random();

            for (int n = 0; n < N; n++)
            {
                var result = random.NextDouble() * 2 * A - A;
                generatedSignal.Add(result);
            }
        }

        public void CreateWavFile()
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
                    bw.Write((byte)Math.Round(generatedSignal[i % generatedSignal.Count]));
                }
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            double A = Convert.ToDouble(textBoxA.Text);
            double f = Convert.ToDouble(textBoxF.Text);
            double Fi = Convert.ToDouble(textBoxFi.Text);
            double D = Convert.ToDouble(textBoxD.Text);
            int N = Convert.ToInt32(comboBoxN.SelectedItem);

            switch (comboBoxWave.SelectedIndex)
            {
                case 0:
                    GenerateSineWave(A, f, Fi, N);
                    break;
                case 1:
                    GeneratePulseWave(A, f, D, N);
                    break;
                case 2:
                    GenerateTriangleWave(A, f, N);
                    break;
                case 3:
                    GenerateSawtoothWave(A, f, N);
                    break;
                case 4:
                    GenerateNoise(A, N);
                    break;
            }

            CreateWavFile();
        }
    }
}

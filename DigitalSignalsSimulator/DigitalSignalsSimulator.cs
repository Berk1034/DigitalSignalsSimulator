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
        private int sampleRate = 44100;

        public DigitalSignalsSimulator()
        {
            InitializeComponent();
            comboBoxWave.SelectedIndex = 0;
        }

        public List<double> GenerateSineWave(double A, double f, double Fi)
        {
            List<double> generatedSignal = new List<double>();
            for (int n = 0; n < sampleRate; n++)
            {
                var result = A * Math.Sin(2 * Math.PI * f * n / sampleRate + Fi);
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public List<double> GeneratePulseWave(double A, double f, double D)
        {
            List<double> generatedSignal = new List<double>();

            for (int n = 0; n < sampleRate; n++)
            {
                var result = ((double)n / sampleRate % (1.0 / f) * f) > D ? 0.0 : A;
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public List<double> GenerateTriangleWave(double A, double f)
        {
            List<double> generatedSignal = new List<double>();
            for (int n = 0; n < sampleRate; n++)
            {
                var result = 2 * A / Math.PI * Math.Asin(Math.Sin(2 * Math.PI * f * n / sampleRate));
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public List<double> GenerateSawtoothWave(double A, double f)
        {
            List<double> generatedSignal = new List<double>();
            for (int n = 0; n < sampleRate; n++)
            {
                var result = - 2 * A / Math.PI * Math.Atan(1.0 / Math.Tan(Math.PI * f * n / sampleRate));
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public List<double> GenerateNoise(double A)
        {
            List<double> generatedSignal = new List<double>();

            Random random = new Random();

            for (int n = 0; n < sampleRate; n++)
            {
                var result = random.NextDouble() * 2 * A - A;
                generatedSignal.Add(result);
            }

            return generatedSignal;
        }

        public void CreateWavFile(int sampleRate, short numChannels, int numSamples, List<double> data)
        {
            byte[] chunkID = Encoding.ASCII.GetBytes("RIFF");
            byte[] format = Encoding.ASCII.GetBytes("WAVE");
            byte[] subChunk1ID = Encoding.ASCII.GetBytes("fmt");
            byte[] subChunk2ID = Encoding.ASCII.GetBytes("data");
            int subChunk1Size = 16;
            short audioFormat = 1;
            short bitsPerSample = 16;
            //short numChannels = 1;
            //int sampleRate = 22050 * 2 * 2;
            int byteRate = sampleRate * numChannels * (bitsPerSample / 8);
            //int numSamples = 1000000;
            short blockAlign = (short)(numChannels * (bitsPerSample / 8));
            int subChunk2Size = numSamples * numChannels * (bitsPerSample / 8);
            int chunkSize = 4 + (8 + subChunk1Size) + (8 + subChunk2Size);

            using (BinaryWriter bw = new BinaryWriter(new FileStream(PATH, FileMode.Create)))
            {
                bw.Write(chunkID);
                bw.Write(chunkSize);
                bw.Write(format);
                bw.Write(subChunk1ID);
                bw.Write((byte)32);
                bw.Write(subChunk1Size);
                bw.Write(audioFormat);
                bw.Write(numChannels);
                bw.Write(sampleRate);
                bw.Write(byteRate);
                bw.Write(blockAlign);
                bw.Write(bitsPerSample);
                bw.Write(subChunk2ID);
                bw.Write(subChunk2Size);

                for (int i = 0; i < numSamples; i++)
                {
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

                switch (comboBoxWave.SelectedIndex)
                {
                    case 0:
                        generatedSignal = GenerateSineWave(A, f, Fi);
                        break;
                    case 1:
                        generatedSignal = GeneratePulseWave(A, f, D);
                        break;
                    case 2:
                        generatedSignal = GenerateTriangleWave(A, f);
                        break;
                    case 3:
                        generatedSignal = GenerateSawtoothWave(A, f);
                        break;
                    case 4:
                        generatedSignal = GenerateNoise(A);
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

            CreateWavFile(sampleRate, 1, 1000000, generatedSignal);
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
                    polyHarmonicsSignal.Add(GenerateSineWave(A, f, Fi));
                    break;
                case 1:
                    polyHarmonicsSignal.Add(GeneratePulseWave(A, f, D));
                    break;
                case 2:
                    polyHarmonicsSignal.Add(GenerateTriangleWave(A, f));
                    break;
                case 3:
                    polyHarmonicsSignal.Add(GenerateSawtoothWave(A, f));
                    break;
                case 4:
                    polyHarmonicsSignal.Add(GenerateNoise(A));
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

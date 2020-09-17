using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace DigitalSignalsSimulator.FileWriters
{
    public class WavFileWriter
    {
        private FileStream fileStream;
        private int sampleRate, numSamples;
        private short numChannels;

        public WavFileWriter(FileStream fileStream, int sampleRate, int numSamples, short numChannels)
        {
            this.fileStream = fileStream;
            this.sampleRate = sampleRate;
            this.numSamples = numSamples;
            this.numChannels = numChannels;
        }

        public void WriteAll(List<double> data)
        {

            float[] newData = data.Select(x => (float)x).ToArray();
            using (WaveFileWriter waveFileWriter = new WaveFileWriter(fileStream, new WaveFormat(sampleRate, 16, numChannels)))
            {
                waveFileWriter.WriteSamples(newData, 0, newData.Length);
            }

            /*
            byte[] chunkID = Encoding.ASCII.GetBytes("RIFF");
            byte[] format = Encoding.ASCII.GetBytes("WAVE");
            byte[] subChunk1ID = Encoding.ASCII.GetBytes("fmt ");
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

            using (BinaryWriter bw = new BinaryWriter(fileStream))
            {
                bw.Write(chunkID);
                bw.Write(chunkSize);
                bw.Write(format);
                bw.Write(subChunk1ID);
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
                    bw.Write((byte)Math.Round(data[i % data.Count]));
                }
            }
            //*/
        }
    }
}

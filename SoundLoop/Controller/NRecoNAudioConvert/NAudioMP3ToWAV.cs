using NAudio.Wave;
using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller.NRecoNAudioConvert
{
    internal class NAudioMP3ToWAV:ConvertBase
    {
        public override void Convert()
        {
            base.Convert();
            try
            {
                using (var mp3Reader = new Mp3FileReader(FilePath))
                using (var waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Reader))
                {
                    var outputWavFilePath = ChangeExtension(FilePath, FormatsData.WAV);
                    WaveFileWriter.CreateWaveFile(outputWavFilePath, waveStream);
                }
                ShowMessage(Success);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        public NAudioMP3ToWAV(string filePath)
        {
            FilePath= filePath;
        }
    }
}

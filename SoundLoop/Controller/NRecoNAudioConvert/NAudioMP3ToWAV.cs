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
        public override void Convert(string MP3File)
        {
            try
            {
                using (var mp3Reader = new Mp3FileReader(MP3File))
                using (var waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Reader))
                {
                    var outputWavFilePath = _ChangeExtension(MP3File, FormatsData.WAV);
                    WaveFileWriter.CreateWaveFile(outputWavFilePath, waveStream);
                }
                _ShowMessage(Success);
            }
            catch (Exception ex)
            {
                _ShowMessage(ex.Message);
            }
        }
    }
}

using NReco.VideoConverter;
using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundLoop.Controller.Extensions;
using NAudio.Wave;
using System.Reflection.PortableExecutable;
using System.Formats.Tar;

namespace SoundLoop.Controller
{
	internal class NRecoNAdioConvert
	{
		Func<string, DialogResult> _Message = MessageBox.Show;
		public void MP4ToMP3(string fileName)
		{
			try
			{
				var outputFile = Path.ChangeExtension(fileName, FormatsData.MP3);
				var convert = new FFMpegConverter();
				convert.ConvertMedia(fileName, outputFile, FormatsData.MP3);
				_Message("Success!");
			}
			catch(Exception ex)
			{
				_Message(ex.Message);
			}
		}

		public void MP3ToWav(string MP3File)
		{        
            try
			{
                using (var mp3Reader = new Mp3FileReader(MP3File))
				using (var waveStream= WaveFormatConversionStream.CreatePcmStream(mp3Reader))
				{
                    var outputWavFilePath = Path.ChangeExtension(MP3File, FormatsData.WAV);
                    WaveFileWriter.CreateWaveFile(outputWavFilePath, waveStream);
                }
				_Message("Success!");
            }
			catch(Exception ex)
			{
				_Message(ex.Message);
            }
        }
		public void WavToMP3(string WavFile)
		{

		}
    }

}



using NReco.VideoConverter;
using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundLoop.Controller.Extensions;
namespace SoundLoop.Controller
{
	internal class NRecoConvert
	{
		public void MP4ToMP3(string fileName)
		{
			try
			{
				var outputFile = Path.ChangeExtension(fileName, FormatsData.MP3);
				var convert = new FFMpegConverter();
				convert.ConvertMedia(fileName, outputFile, FormatsData.MP3);
				MessageBox.Show("success!");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}

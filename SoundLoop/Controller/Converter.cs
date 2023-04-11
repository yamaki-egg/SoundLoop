using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller
{
	internal class Converter
	{
		public static void MP4ToMP3(string fname)
		{
			var inputFile = fname;
			var outputFile = fname;
			
			using (var reader = new MediaFoundationReader(inputFile))
			{
				MediaFoundationEncoder.EncodeToMp3(reader, outputFile);
			}

			
		}
	}
}

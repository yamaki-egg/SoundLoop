
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SoundLoop.Controller
{
	//mp4からmp3など、変換をするクラス
	internal class NRecoFunc
	{
		
		public static void MP4ToMP3(string fname)
		{
			var inputFilePath = fname;
			var outputFilePath = Concat.ChamgeExtension(fname);
            
        }
		class Concat
		{
			StringBuilder _sb = new();

			public static string ChamgeExtension(string fname)
			{
				return Path.ChangeExtension(fname, Enum.GetName(Extension.mp3));
			}
		}
	}
	public enum Extension
	{
		mp3,
		mp4,
		wav
	}
}

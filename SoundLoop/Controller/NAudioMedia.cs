using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
namespace SoundLoop.Controller
{
	internal class NAudioMedia:NAudioFunc
	{
		public override void Read(string fname)
		{

			if (NullState || Stooped)
			{              
				using(_SoundModel.MFR = new(fname))
				{
					_SoundModel.WaveOutEvent.Init(_SoundModel.MFR);
					Play();
				}
			}
		}
		public override void Play()
		{
			Reset(_SoundModel.MFR);
			base.Play();
		}
	}
}


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
namespace SoundLoop.Controller
{
	internal class NAudioSound : NAudioFunc
	{
		public override void Read(string fname)
		{
			if (NullState || Stooped)
			{
				_SoundModel.AFR = new(fname);
				_SoundModel.WaveOutEvent.Init(_SoundModel.AFR);
				Play();
            }
		}
		public override void Play()
		{			
			Reset(_SoundModel.AFR);
			base.Play();
		}
	}
}

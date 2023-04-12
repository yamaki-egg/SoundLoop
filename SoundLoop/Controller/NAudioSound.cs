using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller
{
	internal class NAudioSound : NAudioFunc
	{
		protected override void Loop()
		{
			while (true)
			{
				if (_SoundModel.AFR.Position >= _SoundModel.SoundLength)
					break;
#if DEBUG
				Debug.WriteLine(_SoundModel.AFR.Position);
#endif
			}
			Play();
		}
		public override void Read(string fname)
		{
			_SoundModel.SoundEvent = new();
			_SoundModel.AFR = new(fname);
			_SoundModel.SoundEvent.Init(_SoundModel.AFR);
			_SoundModel.SoundLength = _SoundModel.AFR.Length;
#if DEBUG
			Debug.WriteLine(_SoundModel.SoundLength);
#endif
		}
		public override void Play()
		{
			_SoundModel.AFR.Position = 0;
			base.Play();
		}
	}
}

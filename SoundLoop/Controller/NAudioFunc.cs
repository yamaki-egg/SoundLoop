using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using SoundLoop.Models;

namespace SoundLoop.Controller
{
    abstract internal class NAudioFunc:IReadable
    {
        protected SoundModel _SoundModel = SoundModel.Instance;
		protected bool Stooped=>_SoundModel.WaveOutEvent.PlaybackState== PlaybackState.Stopped;
		protected bool Paused=>_SoundModel.WaveOutEvent.PlaybackState==PlaybackState.Paused;
		protected bool NullState => _SoundModel.WaveOutEvent?.PlaybackState == null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Pause()
        {
            _SoundModel.WaveOutEvent.Pause();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AdjustVolume(float volume)
        {
            _SoundModel.WaveOutEvent.Volume = volume;
        }
		//LoopとPlayは再帰
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public virtual async void Play()
		{
			_SoundModel.WaveOutEvent.Play();
			await Task.Run(Loop);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void Loop()
        {
			while (true)
			{
				if (Stooped)
					break;
				if (Paused)
					return;
			}
			Play();
		}
		protected void Reset(WaveStream waveStream)
		{
			if (Stooped)
			{
				waveStream.Position = 0;			
			}
		}
		public virtual void Read(string fname) { }


	}
}

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

namespace SoundLoop.Controller.NAudio
{
    abstract internal class NAudioBase : IUserPlaybackable,ISoundModelProvider
    {
        public SoundModel SoundModel => SoundModel.Instance;

        protected bool Stooped => SoundModel.WaveOutEvent.PlaybackState == PlaybackState.Stopped;
        protected bool Paused => SoundModel.WaveOutEvent.PlaybackState == PlaybackState.Paused;
        protected bool NullState => SoundModel.WaveOutEvent?.PlaybackState == null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Pause()
        {
            SoundModel.WaveOutEvent.Pause();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AdjustVolume(float volume)
        {
            SoundModel.WaveOutEvent.Volume = volume;
        }
        //LoopとPlayは再帰
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual async void Play()
        {
            SoundModel.WaveOutEvent.Play();

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

        public void Resume()
        {
            if (Paused)
            {
                Play();
            }
        }

		public void Stop(WaveStream waveStream)
		{
			if(waveStream == null)
                return;
            Pause();
            SoundModel.WaveOutEvent.Stop();
			waveStream.Dispose();
		}
	}
}

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
        public SoundData SoundData => SoundData.Instance;

        protected bool Stooped => SoundData.WaveOutEvent.PlaybackState == PlaybackState.Stopped;
        protected bool Paused => SoundData.WaveOutEvent.PlaybackState == PlaybackState.Paused;
        protected bool NullState => SoundData.WaveOutEvent?.PlaybackState == null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Pause()
        {
            SoundData.WaveOutEvent.Pause();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AdjustVolume(float volume)
        {
            SoundData.WaveOutEvent.Volume = volume;
        }
        //LoopとPlayは再帰
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual async void Play()
        {
            SoundData.WaveOutEvent.Play();

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
            SoundData.WaveOutEvent.Stop();
			waveStream.Dispose();
		}
	}
}

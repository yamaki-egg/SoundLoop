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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual async void Play()
        {
            _SoundModel.SoundEvent.Play();
            await Task.Run(Loop);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Pause()
        {
            _SoundModel.SoundEvent.Pause();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AdjustVolume(float volume)
        {
            _SoundModel.SoundEvent.Volume = volume;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract void Loop();

		public virtual void Read(string fname) { }

	}
}

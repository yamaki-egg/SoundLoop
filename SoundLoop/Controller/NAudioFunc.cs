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
    internal class NAudioFunc
    {
        SoundModel _SoundModel = SoundModel.Instance;
        public void ReadSoundF(string fname)
        {
            _SoundModel.SoundEvent = new();
            _SoundModel.AFR = new(fname);
            _SoundModel.SoundEvent.Init(_SoundModel.AFR);
            _SoundModel.SoundLength = _SoundModel.AFR.Length;
#if DEBUG
            Debug.WriteLine(_SoundModel.SoundLength);
#endif
        }
        public void ReadMediaF(string fname)
        {
            _SoundModel.SoundEvent=new();
            _SoundModel.MFR = new(fname);
            _SoundModel.SoundEvent.Init(_SoundModel.MFR);
            _SoundModel.SoundLength= _SoundModel.MFR.Length;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async void Play()
        {
            _SoundModel.AFR.Position = 0;
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
        void Loop()
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
    }
}

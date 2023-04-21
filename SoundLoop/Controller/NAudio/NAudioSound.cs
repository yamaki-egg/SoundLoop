
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SoundLoop.Controller.NAudio
{
    internal class NAudioSound : NAudioBase
    {
        public override void Read(string fname)
        {
            if (NullState || Stooped)
            {
                SoundData.WaveStream = new AudioFileReader(fname);
                SoundData.WaveOutEvent.Init(SoundData.WaveStream);
                Play();
            }
        }
        public override void Play()
        {
            Reset(SoundData.WaveStream);
            base.Play();
        }
    }
}

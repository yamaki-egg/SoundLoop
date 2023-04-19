
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SoundLoop.Controller.NAudio
{
    internal class NAudioSound : NAudioFunc
    {
        public override void Read(string fname)
        {
            if (NullState || Stooped)
            {
                SoundModel.AFR = new(fname);
                SoundModel.WaveOutEvent.Init(SoundModel.AFR);
                Play();
            }
        }
        public override void Play()
        {
            Reset(SoundModel.AFR);
            base.Play();
        }
    }
}

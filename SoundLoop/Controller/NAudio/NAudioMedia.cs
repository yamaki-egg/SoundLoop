using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SoundLoop.Controller.NAudio
{
    internal class NAudioMedia : NAudioFunc
    {
        public override void Read(string fname)
        {
            if (NullState || Stooped)
            {
                using (SoundModel.MFR = new(fname))
                {
                    SoundModel.WaveOutEvent.Init(SoundModel.MFR);
                    Play();
                }
            }
        }
        public override void Play()
        {
            Reset(SoundModel.MFR);
            base.Play();
        }
    }
}

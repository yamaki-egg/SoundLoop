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
    internal class NAudioMedia : NAudioBase
    {
        public override void Read(string fname)
        {
            if (NullState || Stooped)
            {
                using (SoundModel.WaveStream = new MediaFoundationReader(fname))
                {
                    SoundModel.WaveOutEvent.Init(SoundModel.WaveStream);
                    Play();
                }
            }
        }
        public override void Play()
        {
            Reset(SoundModel.WaveStream);
            base.Play();
        }
    }
}

using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Models
{
    internal class SoundModel
    {
        static readonly object _lockObject = new();
        public WaveOutEvent SoundEvent { get; } = new();
        public AudioFileReader AFR { get; set; }
        public MediaFoundationReader MFR { get; set; }
        public string Fname { get; set; }
		SoundModel() { }
        public static SoundModel Instance
        {
            get
            {
                lock (_lockObject)
                {
                    _instance ??= new();
                }
                return _instance;
            }
        }
        public static SoundModel _instance;
    }
}

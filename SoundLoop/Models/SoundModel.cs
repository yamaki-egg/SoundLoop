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
        public WaveOutEvent SoundEvent { get; set; }
        public AudioFileReader AFR { get; set; }
        public MediaFoundationReader MFR { get; set; }
        public string Fname { get; set; }
        public string Mfname { get; set; }
        public double SoundLength { get; set; }
        SoundModel() { }
        public static SoundModel Instance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                        _instance = new();
                }
                return _instance;
            }
        }
        public static SoundModel _instance;
    }
}

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
        WaveOutEvent _waveOutEvent = new();
        AudioFileReader _audioFileReader;
        public WaveOutEvent WaveOutEvent
        {
            get => _waveOutEvent;
            set
			{
                if (_waveOutEvent == null)
                    return;
				_waveOutEvent.Dispose();
				_waveOutEvent = value;

			}
		}
        public AudioFileReader AFR
        {
            get => _audioFileReader;
            set
            {
                if(_audioFileReader == null)
                {
                    _audioFileReader = value;
                }
                else
                {
                    _audioFileReader.Dispose();
                    _audioFileReader = value;
                }
            }
        }
        public MediaFoundationReader MFR { get; set; }

        public string Fname { get; set; }
		SoundModel()
        {
            
        }
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

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
        WaveStream _waveStream;
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
        public WaveStream WaveStream
        {
            get => _waveStream;
            set
            {
                if(_waveStream == null)
                {
                    _waveStream = value;
                }
                else
                {
                    _waveStream.Dispose();
                    _waveStream = value;
                }
            }
        }

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

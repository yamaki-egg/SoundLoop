using SoundLoop.Controller.NAudio;
using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller
{
    internal class Form1Events:ISoundModelProvider
    {
        IUserPlaybackable _NAudio;
        NRecoNAdioConvert _NRecoConvert = new();
        public SoundModel SoundModel => SoundModel.Instance;
        public ToolStripStatusLabel Status {  get; init; }
        public TrackBar VolumeBar { get; init; }
        public Form Form {  get; init; }
        public Form1Events(ToolStripStatusLabel status,TrackBar trackBar,Form form)
        {
            Status = status;
            VolumeBar = trackBar;
            Form = form;
        }
        public void FormOpen_Click(object sender, EventArgs e)
        {
            (SoundModel.Fname,_NAudio) =UFileDialog.FileOpen();
            _NAudio.Read(SoundModel.Fname);
            Status.Text = Path.GetFileName(SoundModel.Fname);
        }
        public void Form1Play_Click(object sender, EventArgs e)
        {
            SoundModel.WaveOutEvent.Play();   
        }
        public void Form1Pause_Click(object sender, EventArgs e)
        {
            _NAudio.Pause();
        }
        public void Form1Volume_Change(object sender, EventArgs e)
        {
            if (SoundModel.WaveOutEvent is null)
                return;
            var adjustVolumeNum = 100f;
			_NAudio.AdjustVolume(VolumeBar.Value / adjustVolumeNum);
		}
        public void Form1Close_Key(object sender, FormClosingEventArgs e)
        {
        }
        public void MP4ToMP3Convert_Click(object sender, EventArgs e)
        {
            if(SoundModel.Fname.Length==0)
                return;
            _NRecoConvert.MP4ToMP3(SoundModel.Fname);
        }
        public void MP3ToWavConvert_Click(object sender, EventArgs e)
        {
            if (SoundModel.Fname.Length == 0)
                return;
            _NRecoConvert.MP3ToWav(SoundModel.Fname);
        }
    }
}

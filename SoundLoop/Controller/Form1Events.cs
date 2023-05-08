using SoundLoop.Controller.Factory;
using SoundLoop.Controller.NAudio;
using SoundLoop.Controller.NRecoNAudioConvert;
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
        public SoundData SoundData => SoundData.Instance;
        public ToolStripStatusLabel Status {  get; init; }
        public TrackBar VolumeBar { get; init; }
        public Form Form {  get; init; }
        public Form1Events(ToolStripStatusLabel status,TrackBar trackBar,Form form)
        {
            Status = status;
            VolumeBar = trackBar;
            Form = form;
        }
        public async void FormOpen_Click(object sender, EventArgs e)
        {
            SoundData.Fname =UFileDialog.FileOpen();
            if (string.IsNullOrEmpty(SoundData.Fname))
                return;
            _NAudio=FactoryNAudio.Create(SoundData.Fname);
            await _NAudio.Read(SoundData.Fname);
            Status.Text = Path.GetFileName(SoundData.Fname);
        }
        public void Form1Play_Click(object sender, EventArgs e)
        {
            SoundData.WaveOutEvent.Play();   
        }
        public void Form1Pause_Click(object sender, EventArgs e)
        {
            _NAudio.Pause();
        }
        public void Form1Volume_Change(object sender, EventArgs e)
        {
            if (SoundData.WaveOutEvent is null)
                return;
            var adjustVolumeNum = 100f;
			_NAudio.AdjustVolume(VolumeBar.Value / adjustVolumeNum);
		}
        public void Form1Stop_Click(object sender, EventArgs e)
        {
            _NAudio.Stop(SoundData.WaveStream);
        }
        public void MP4ToMP3Convert_Click(object sender, EventArgs e)
        {
			SoundData.Fname=UFileDialog.InvokeFileOpen(SoundData.Fname);
            IConverter converter = FactoryConvert.Create(SoundData.Fname);
            converter.Convert();
        }
        public void MP3ToWavConvert_Click(object sender, EventArgs e)
        {
			SoundData.Fname=UFileDialog.InvokeFileOpen(SoundData.Fname);
            IConverter converter = FactoryConvert.Create(SoundData.Fname);
            converter.Convert();
        }
    }
}

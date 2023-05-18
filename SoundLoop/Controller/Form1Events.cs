using SoundLoop.Controller.Factory;
using SoundLoop.Controller.NAudio;
using SoundLoop.Controller.NRecoNAudioConvert;
using SoundLoop.Models;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller
{
    internal class Form1Events:ISoundModelProvider
    {
        IUserPlaybackable _NAudio;
        private System.Windows.Forms.Timer _timer = new();
        public SoundData SoundData => SoundData.Instance;
        public ToolStripStatusLabel Status {  get; init; }
        public TrackBar VolumeBar { get; init; }
        public TrackBar TimeBar { get; init; }
        public Form Form {  get; init; }
        public Form1Events(ToolStripStatusLabel status,TrackBar trackBar,TrackBar timeBar,Form form)
        {
            Status = status;
            VolumeBar = trackBar;
            TimeBar = timeBar;
            Form = form;
        }
        public void FormOpen_Click(object sender, EventArgs e)
        {
            SoundData.Fname =UFileDialog.FileOpen();
            if (string.IsNullOrEmpty(SoundData.Fname))
                return;
            _NAudio=FactoryNAudio.Create(SoundData.Fname);
            
            Status.Text = Path.GetFileName(SoundData.Fname);
        }
        public async void Form1Play_Click(object sender, EventArgs e)
        {
			await _NAudio.Read(SoundData.Fname);
            TimeTrackBarSetMaximum();
            _timer.Interval=100;
            _timer.Tick += Timer_Tick;
            _timer.Start();
		}
        public void Form1Pause_Click(object sender, EventArgs e)
        {
            _NAudio.Pause();
        }
        private void TimeTrackBarSetMaximum()
        {
            TimeBar.Maximum = (int)SoundData.WaveStream.TotalTime.TotalSeconds;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeBar.Value=(int)SoundData.WaveStream.CurrentTime.TotalSeconds;
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

using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller
{
    internal class Form1Events
    {
        NAudioFunc _NAudioFunc;
        NRecoConvert _NRecoConvert = new();
        SoundModel _SoundModel = SoundModel.Instance;
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
            (_SoundModel.Fname,_NAudioFunc) =UFileDialog.FileOpen();
        }
        public void Form1Play_Click(object sender, EventArgs e)
        {
            if (_SoundModel.Fname.Length == 0)
                return;
            _NAudioFunc.Read(_SoundModel.Fname);
            _NAudioFunc.Play();
           
            Status.Text=Path.GetFileName(_SoundModel.Fname);
        }
        public void Form1Pause_Click(object sender, EventArgs e)
        {
            _NAudioFunc.Pause();
        }
        public void Form1Volume_Change(object sender, EventArgs e)
        {
            if (_SoundModel.SoundEvent is null)
                return;
            var adjustVolumeNum = 100f;
			_NAudioFunc.AdjustVolume(VolumeBar.Value / adjustVolumeNum);
		}
        public void Form1Close_Key(object sender, FormClosingEventArgs e)
        {
        }
        public void MP4ToMP3Convert_Click(object sender, EventArgs e)
        {
            if(_SoundModel.Fname.Length==0)
                return;
            _NRecoConvert.MP4ToMP3(_SoundModel.Fname);
        }
    }
}

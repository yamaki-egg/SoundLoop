using SoundLoop.Controller;

namespace SoundLoop
{
	public partial class Form1 : Form
	{
		Form1Events _form1Events;
		public Form1()
		{
			InitializeComponent();

			_form1Events = new(fnameStripStatusLabel, volumeTrackBar, this);

			openToolStripMenuItem.Click += _form1Events.FormOpen_Click;
			playToolStripMenuItem.Click += _form1Events.Form1Play_Click;
			stopToolStripMenuItem.Click += _form1Events.Form1Pause_Click;
			volumeTrackBar.ValueChanged += _form1Events.Form1Volume_Change;
			mp4Tomp3ToolStripMenuItem.Click += _form1Events.MP4ToMP3Convert_Click;
			//this.KeyDown += Form1Events.Form1Close_Key;
		}


	}
}
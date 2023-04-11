using SoundLoop.Controller;

namespace SoundLoop
{
	public partial class Form1 : Form
	{
		Form1Events Form1Events { get; set; }
		public Form1()
		{
			InitializeComponent();

			Form1Events = new(fnameStripStatusLabel, volumeTrackBar, this);

			openToolStripMenuItem.Click += Form1Events.FormOpen_Click;
			playToolStripMenuItem.Click += Form1Events.Form1Play_Click;
			stopToolStripMenuItem.Click += Form1Events.Form1Pause_Click;
			volumeTrackBar.ValueChanged += Form1Events.Form1Volume_Change;
			mp4Tomp3ToolStripMenuItem.Click += Form1Events.MP4ToMP3Convert_Click;
			this.KeyDown += Form1Events.Form1Close_Key;
		}


	}
}
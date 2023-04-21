using SoundLoop.Controller;

namespace SoundLoop
{
	public partial class Form1 : Form
	{
		Form1Events _form1Events;
		public Form1()
		{
			InitializeComponent();
			Text = "SoundLoop";

			Icon = new Icon(GetIconPath());

			_form1Events = new(fnameStripStatusLabel, volumeTrackBar, this);

			openToolStripMenuItem.Click += _form1Events.FormOpen_Click;
			playToolStripMenuItem.Click += _form1Events.Form1Play_Click;
			stopToolStripMenuItem.Click += _form1Events.Form1Stop_Click;
			pauseToolStripMenuItem1.Click += _form1Events.Form1Pause_Click;
			volumeTrackBar.ValueChanged += _form1Events.Form1Volume_Change;
			mp4Tomp3ToolStripMenuItem.Click += _form1Events.MP4ToMP3Convert_Click;
			mp3ToWavToolStripMenuItem.Click += _form1Events.MP3ToWavConvert_Click;
		}
		string GetIconPath()
		{
			var iconPath=Directory.GetCurrentDirectory();
			if (string.IsNullOrEmpty(iconPath))
				return null;
			for (int i = 0; i < 4; i++)
			{
				var t=iconPath.LastIndexOf(@"\");
				iconPath=iconPath.Substring(0, t);
			}
			return Path.Combine(iconPath, "Icon", "audio.ico");
		}

	}
}
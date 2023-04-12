using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller
{
    internal class UFileDialog
    {
        public static (string,NAudioFunc) FileOpen(string fileter= "音声ファイル(*.wav,*.mp3,*.mp4|*.wav;*.mp3;*.mp4|" + "すべてのファイル(*.*)|*.*")
        {
            string fname = null;
            using(var openDialog=new OpenFileDialog())
            {
                openDialog.Filter = fileter;
                openDialog.FilterIndex = 1;
                openDialog.CheckFileExists= true;
                if(openDialog.ShowDialog() == DialogResult.OK)
                    fname = openDialog.FileName;
            }
            return (fname,ExtCheck(fname));
        }
        public static NAudioFunc ExtCheck(string fname)
        {
            if (Path.GetExtension(fname) == FormatsData.MP4)
                return new NAudioMedia();
            else
                return new NAudioMedia();
        }
    }
}

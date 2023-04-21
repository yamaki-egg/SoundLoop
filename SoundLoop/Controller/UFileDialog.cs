using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using SoundLoop.Controller.Extensions;
using SoundLoop.Controller.NAudio;

namespace SoundLoop.Controller
{
    internal class UFileDialog
    {
        public static string FileOpen(string fileter= "音声ファイル(*.wav,*.mp3,*.mp4|*.wav;*.mp3;*.mp4|" + "すべてのファイル(*.*)|*.*")
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
            return fname;
        }
        [Pure]
        public string InvokeFileOpen(string fname)
        {
            if(!File.Exists(fname) || string.IsNullOrEmpty(fname))
            {
                fname=FileOpen();
            }
            return fname;
        }
    }
}

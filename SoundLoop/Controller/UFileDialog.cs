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
        public static string FileOpen(string fileter= "音声ファイル(*.wav,*mp3,|*.wav;*.mp3|" + "すべてのファイル(*.*)|*.*")
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
    }
}

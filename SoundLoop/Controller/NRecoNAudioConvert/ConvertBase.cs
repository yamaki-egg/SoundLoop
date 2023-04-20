using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller.NRecoNAudioConvert
{
    abstract internal class ConvertBase : IConverter
    {
        protected Func<string,DialogResult> ShowMessage => MessageBox.Show;
        protected Func<string, string, string> ChangeExtension => Path.ChangeExtension;
        protected string Success => "Success!";
        public abstract void Convert(string filePath);
    }
}

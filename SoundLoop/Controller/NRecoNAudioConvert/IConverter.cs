using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller.NRecoNAudioConvert
{
    internal interface IConverter
    {
        void Convert(string filePath);
    }
}

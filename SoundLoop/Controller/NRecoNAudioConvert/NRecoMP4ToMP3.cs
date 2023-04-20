using NReco.VideoConverter;
using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller.NRecoNAudioConvert
{
    internal class NRecoMP4ToMP3:ConvertBase
    {
        public override void Convert(string fileName)
        {
            try
            {
                var outputFile=_ChangeExtension(fileName,FormatsData.MP3);
                var convert = new FFMpegConverter();
                convert.ConvertMedia(fileName, outputFile, FormatsData.MP3);
                _ShowMessage(Success);
            }
            catch (Exception ex)
            {
                _ShowMessage(ex.Message);
            }
        }
    }
}

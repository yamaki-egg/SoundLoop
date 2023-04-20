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
                var outputFile=ChangeExtension(fileName,FormatsData.MP3);
                var convert = new FFMpegConverter();
                convert.ConvertMedia(fileName, outputFile, FormatsData.MP3);
                ShowMessage(Success);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
    }
}

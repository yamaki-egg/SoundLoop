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
        public override void Convert()
        {
            base.Convert();
            try
            {
                var outputFile=ChangeExtension(FilePath,FormatsData.MP3);
                var convert = new FFMpegConverter();
                convert.ConvertMedia(FilePath, outputFile, FormatsData.MP3);
                ShowMessage(Success);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        public NRecoMP4ToMP3(string filePath)
        {
            FilePath = filePath;
        }
    }
}

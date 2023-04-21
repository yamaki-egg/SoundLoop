using SoundLoop.Controller.Extensions;
using SoundLoop.Controller.NRecoNAudioConvert;
using SoundLoop.Models;

namespace SoundLoop.Controller.Factory
{
    internal class FactoryConvert : IFactory<IConverter>
    {
        public static IConverter Create(string filePath)
        {
            return filePath?.GetExtensionWithoutPeriod() switch
            {
                FormatsData.MP4 => new NRecoMP4ToMP3(filePath),
                _ => new NAudioMP3ToWAV(filePath)
            };
        }
    }
}

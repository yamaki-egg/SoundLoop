using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop
{
    internal interface ISoundModelProvider
    {
        SoundData SoundModel { get; }
    }
}

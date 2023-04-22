using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if DEBUG
namespace SoundLoop.Controller.SoundDebugs
{

	internal class SoundLoopDebug
	{
		int MegaByte => 1024;
		public void MemoryCheck()
		{
            var totalMemory = GC.GetTotalMemory(false);
            var remainingMemory = GC.MaxGeneration * MegaByte * MegaByte - totalMemory;
            Debug.WriteLine($"Remaining stack memory: {remainingMemory}bytes");
        }
	}
}
#endif

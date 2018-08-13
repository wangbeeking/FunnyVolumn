using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyVolumn
{
    public class VolumnControler
    {
        public static IVolumnControler VolumnHandler = new TestVolumn();
        public static void Initialize(VolumnControlerType vct)
        {
            switch(vct)
            {
                case VolumnControlerType.TEST:
                    VolumnHandler = new TestVolumn();break;
                case VolumnControlerType.KEYBOARD:
                    VolumnHandler = new KeyboardVolumn();break;
                case VolumnControlerType.WAVE:
                    VolumnHandler = new WaveVolumn();break;
            }
        }
    }
}

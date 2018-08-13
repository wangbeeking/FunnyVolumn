using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyVolumn
{
    public interface IVolumnControler
    {
        UInt32 GetVolumn();
        UInt32 AddVolumn(UInt32 addValue = 1);
        UInt32 SubVolumn(UInt32 subValue = 1);
        UInt32 SetVolumn(UInt32 inValue = 1);
    }
}

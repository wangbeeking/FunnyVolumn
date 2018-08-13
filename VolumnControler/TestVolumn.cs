using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyVolumn
{
    public class TestVolumn : IVolumnControler
    {
        #region 存储变量
        private static uint CurrentVolumn = 50;
        private static object LockObj = new object();
        #endregion
        public uint AddVolumn(uint addValue = 1)
        {
            lock (LockObj)
            {
                CurrentVolumn = CurrentVolumn + addValue > 100 ? 100 : CurrentVolumn + addValue;
            }
            return CurrentVolumn;
        }

        public uint GetVolumn()
        {
            return CurrentVolumn;
        }

        public uint SetVolumn(uint inValue = 1)
        {
            lock (LockObj)
            {
                if (inValue > 100)
                    CurrentVolumn = 100;
                else if (inValue < 0)
                    CurrentVolumn = 0;
                else
                    CurrentVolumn = inValue;
            }
            return CurrentVolumn;
        }

        public uint SubVolumn(uint subValue = 1)
        {
            lock (LockObj)
            {
                if (CurrentVolumn == 0)
                    return CurrentVolumn;
                CurrentVolumn = CurrentVolumn <= subValue ? 0 : CurrentVolumn - subValue;
                System.Diagnostics.Debug.WriteLine(CurrentVolumn);
            }
            return CurrentVolumn;
        }
    }
}

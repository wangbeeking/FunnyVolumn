using System;
using System.Runtime.InteropServices;

namespace FunnyVolumn
{
    public class WaveVolumn:IVolumnControler
    {
        #region 库定义
        [DllImport("winmm.dll")]
        private static extern long waveOutSetVolume(UInt32 deviceID, UInt32 Volume);
        [DllImport("winmm.dll")]
        private static extern long waveOutGetVolume(UInt32 deviceID, ref UInt32 Volume);

        private const UInt32 HandleID = 0;
        #endregion

        public uint GetVolumn()
        {
            UInt32 volumn = 0;
            long i = waveOutGetVolume(0, ref volumn);
            return volumn;
        }

        public uint AddVolumn(uint addValue = 1)
        {
            throw new NotImplementedException();
        }

        public uint SubVolumn(uint subValue = 1)
        {
            throw new NotImplementedException();
        }
        public void Mute(bool isMute = true)
        {
            throw new NotImplementedException();
        }

        public uint SetVolumn(uint inValue = 1)
        {
            throw new NotImplementedException();
        }
    }
}
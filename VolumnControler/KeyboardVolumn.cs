using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FunnyVolumn
{
    public class KeyboardVolumn: IVolumnControler
    {
        #region 库定义
        private const byte VK_VOLUME_MUTE = 0xAD;
        private const byte VK_VOLUME_DOWN = 0xAE;
        private const byte VK_VOLUME_UP = 0xAF;
        private const UInt32 KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const UInt32 KEYEVENTF_KEYUP = 0x0002;

        public KeyboardVolumn()
        {
        }

        [DllImport("user32.dll")]
        static extern void Keybd_event(byte bVk, byte bScan, UInt32 dwFlags, UInt32 dwExtraInfo);

        [DllImport("user32.dll")]
        static extern Byte MapVirtualKey(UInt32 uCode, UInt32 uMapType);
        #endregion
        
        public uint GetVolumn()
        {
            throw new NotImplementedException();
        }

        public uint AddVolumn(uint addValue = 1)
        {
            Keybd_event(VK_VOLUME_UP, MapVirtualKey(VK_VOLUME_UP, 0), KEYEVENTF_EXTENDEDKEY, 0);
            Keybd_event(VK_VOLUME_UP, MapVirtualKey(VK_VOLUME_UP, 0), KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            return 0;
        }

        public uint SubVolumn(uint subValue = 1)
        {
            Keybd_event(VK_VOLUME_DOWN, MapVirtualKey(VK_VOLUME_DOWN, 0), KEYEVENTF_EXTENDEDKEY, 0);
            Keybd_event(VK_VOLUME_DOWN, MapVirtualKey(VK_VOLUME_DOWN, 0), KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            return 0;
        }

        public void Mute(bool isMute = true)
        {
            Keybd_event(VK_VOLUME_MUTE, MapVirtualKey(VK_VOLUME_MUTE, 0), KEYEVENTF_EXTENDEDKEY, 0);
            Keybd_event(VK_VOLUME_MUTE, MapVirtualKey(VK_VOLUME_MUTE, 0), KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        public uint SetVolumn(uint inValue = 1)
        {
            throw new NotImplementedException();
        }
    }
}

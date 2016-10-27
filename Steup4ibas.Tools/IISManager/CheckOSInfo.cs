using System;
using System.Runtime.InteropServices;

namespace Steup4ibas.Tools.IISManager
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct _OSVERSIONINFOEX
    {
        public Int32 dwOSVersionInfoSize;
        public Int32 dwMajorVersion;
        public Int32 dwMinorVersion;
        public Int32 dwBuildNumber;
        public Int32 dwPlatformId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public Char[] szCSDVersion;
        public Int16 wServicePackMajor;
        public Int16 wServicePackMinor;
        public Int16 wSuiteMask;
        public Byte wProductType;
        public Byte wReserved;
    }
    /// <summary>
    /// 获得OS信息
    /// </summary>
    public class CheckOSInfo
    {
        [DllImport("kernel32.dll")]
        public static extern bool GetVersionEx(ref _OSVERSIONINFOEX osVersionInfo);
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int sm_SERVERR2);


        public static string GetOSName()
        {
            _OSVERSIONINFOEX osVersionInfo = new _OSVERSIONINFOEX();
            osVersionInfo.dwOSVersionInfoSize = 156;

            if (GetVersionEx(ref osVersionInfo))
            {
                switch (osVersionInfo.dwMajorVersion)
                {
                    case 5:
                        switch (osVersionInfo.dwMinorVersion)
                        {
                            case 0:
                                return "Microsoft Windows 2000";
                            case 1:
                                return "Microsoft Windows XP";
                            case 2:
                                if ((osVersionInfo.wSuiteMask & 0x00008000) != 0)
                                    return "Microsoft Windows Home Server";
                                if (osVersionInfo.wProductType == 1 && CheckOSBitness.Is64BitOperatingSystem())
                                    return "Microsoft Windows XP";
                                if (GetSystemMetrics(89) == 0)
                                    return "Microsoft Windows Server 2003";
                                else
                                    return "Microsoft Windows Server 2003 R2";
                        }
                        break;
                    case 6:
                        switch (osVersionInfo.dwMinorVersion)
                        {
                            case 0:
                                if (osVersionInfo.wProductType == 1)
                                    return "Microsoft Windows Vista";
                                else
                                    return "Microsoft Windows Server 2008";
                            case 1:
                                if (osVersionInfo.wProductType == 1)
                                    return "Microsoft Windows 7";
                                else
                                    return "Microsoft Windows Server 2008 R2";
                            default:
                                return "The later version of Microsoft Windows Vista";
                        }
                        break;
                }
            }
            return null;
        }
    }
}

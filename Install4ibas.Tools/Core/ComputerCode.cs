using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install4ibas.Tools.Core
{
    public static class ComputerCode
    {
        public static string GetCode()
        {
            var cpuid = GetCpuId();
            var hostname = System.Net.Dns.GetHostName();
            var cupDatas = System.Text.Encoding.Default.GetBytes(cpuid);
            var hostDatas = System.Text.Encoding.Default.GetBytes(hostname);
            var length = cupDatas.Length >= hostname.Length ? cupDatas.Length : hostname.Length;
            var keyDatas = new byte[length];
            byte cup, host, key;
            for (int i = 0; i < length; i++)
            {
                cup = i < cupDatas.Length ? cupDatas[i] : (byte)0x01;
                host = i < hostDatas.Length ? hostDatas[i] : (byte)0x01;
                key = (byte)(cup ^ host);
                keyDatas[i] = key;
            }
            var keyCode = ToHexString(keyDatas);
            return keyCode;
        }


        /// <summary>
        /// 读取CPU机器码
        /// </summary>
        /// <returns></returns>
        public static string GetCpuId()
        {
            string cpuInfo = string.Empty;
            using (System.Management.ManagementClass cimobject = new System.Management.ManagementClass("Win32_Processor"))
            {
                System.Management.ManagementObjectCollection moc = cimobject.GetInstances();
                foreach (var mo in moc)
                {
                    cpuInfo = Convert.ToString(mo.Properties["ProcessorId"].Value);
                    mo.Dispose();
                }
            }
            return cpuInfo;
        }

        /// <summary>
        /// 0xae00cf => "AE00CF "
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            } return hexString;
        }
    }
}

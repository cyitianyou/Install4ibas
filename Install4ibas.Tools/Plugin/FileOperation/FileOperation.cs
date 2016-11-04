using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Install4ibas.Tools.Plugin.FileOperation
{
    public class FileOperation
    {
        const string WebFolderName = "Install4ibas.Tools.WebFile.";
        public static void CopyResourceFiles(string Path)
        {
            var ResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            foreach (var ResourceName in ResourceNames)
            {
                var fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName);
                if (fileStream == null) continue;
            }
        }

        public static void RunBatFile(string filename)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = filename;
               // proc.StartInfo.Arguments = string.Format("10");//this is argument
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0}运行失败,{1}，{2}",filename, ex.Message, ex.StackTrace.ToString());
            }
        }
    }
}

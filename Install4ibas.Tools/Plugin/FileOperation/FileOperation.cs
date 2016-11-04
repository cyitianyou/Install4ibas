using System;
using System.Collections.Generic;
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
    }
}

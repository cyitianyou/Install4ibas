using Install4ibas.Tools.Common.InstallInformation;
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
        const string WebFolderName = "Install4ibas.Tools.Resource.WebFile.";
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
        public static IList<ibasModule> LoadModules(string SourcePath)
        {
            IList<ibasModule> Modules = new List<ibasModule>();
            try
            {
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（srcPath）；
                string[] fileList = System.IO.Directory.GetFileSystemEntries(SourcePath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    　if(System.IO.Directory.Exists(file))
                  　{
                         continue;
                     }
                    string filename = Path.GetFileName(file);
                    if (filename.StartsWith("ibas_4_modules_published") && filename.EndsWith("zip"))
                    {
                        string modulename = filename.Substring(filename.LastIndexOf("_BizSys") + 8, filename.Length - filename.LastIndexOf("_BizSys") - 12);
                        ibasModule module = new ibasModule();
                        module.ModuleName = modulename;
                        module.IsShell = false;
                        Modules.Add(module);
                    }
                    else if (filename.StartsWith("ibas_4_shell_published") && filename.EndsWith("zip"))
                    {
                         ibasModule module = new ibasModule();
                         module.ModuleName = "shell";
                         module.IsShell = true;
                         Modules.Add(module);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return Modules;
        }

        public static IList<ibasModule> LoadAndCopyModules(string SourcePath, string InstallPath)
        {
            IList<ibasModule> Modules = new List<ibasModule>();
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加
                if (InstallPath[InstallPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                {
                    InstallPath += System.IO.Path.DirectorySeparatorChar;
                }
                // 判断目标目录是否存在如果不存在则新建
                if (!System.IO.Directory.Exists(InstallPath))
                {
                    System.IO.Directory.CreateDirectory(InstallPath);
                }
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（srcPath）；
                string[] fileList = System.IO.Directory.GetFileSystemEntries(SourcePath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    if (System.IO.Directory.Exists(file))
                    {
                        continue;
                    }
                    string filename = Path.GetFileName(file);
                    if (filename.StartsWith("ibas_4_modules_published") && filename.EndsWith("zip"))
                    {
                        System.IO.File.Copy(file, InstallPath + filename, true);
                        string modulename = filename.Substring(filename.LastIndexOf("_BizSys") + 8, filename.Length - filename.LastIndexOf("_BizSys") - 12);
                        ibasModule module = new ibasModule();
                        module.ModuleName = modulename;
                        module.ModuleInstallPath = InstallPath + "\\" + filename;
                        module.IsShell = false;
                        Modules.Add(module);
                    }
                    else if (filename.StartsWith("ibas_4_shell_published") && filename.EndsWith("zip"))
                    {
                        System.IO.File.Copy(file, InstallPath + filename, true);
                        ibasModule module = new ibasModule();
                        module.ModuleName = "shell";
                        module.IsShell = true;
                        Modules.Add(module);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return Modules;
        }

        public static IList<ibasModule> CopyModules(string SourcePath, string InstallPath,IList<ibasModule> Modules)
        {
            if (Modules == null || Modules.Count == 0) return Modules;
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加
                if (InstallPath[InstallPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                {
                    InstallPath += System.IO.Path.DirectorySeparatorChar;
                }
                // 判断目标目录是否存在如果不存在则新建
                if (!System.IO.Directory.Exists(InstallPath))
                {
                    System.IO.Directory.CreateDirectory(InstallPath);
                }
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（srcPath）；
                string[] fileList = System.IO.Directory.GetFileSystemEntries(SourcePath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    if (System.IO.Directory.Exists(file))
                    {
                        continue;
                    }
                    string filename = Path.GetFileName(file);
                    if (filename.StartsWith("ibas_4_modules_published") && filename.EndsWith("zip"))
                    {
                        
                        string modulename = filename.Substring(filename.LastIndexOf("_BizSys") + 8, filename.Length - filename.LastIndexOf("_BizSys") - 12);
                        var module = Modules.FirstOrDefault(c => c.ModuleName == modulename);
                        if (module == null) continue;
                        module.ModuleInstallPath = InstallPath + "\\" + filename;
                        module.IsShell = false;
                        System.IO.File.Copy(file, InstallPath + filename, true);
                    }
                    else if (filename.StartsWith("ibas_4_shell_published") && filename.EndsWith("zip"))
                    {
                        var module = Modules.FirstOrDefault(c => c.ModuleName == "shell");
                        if (module == null) continue;
                        module.ModuleInstallPath = InstallPath + "\\" + filename;
                        module.IsShell = true;
                        System.IO.File.Copy(file, InstallPath + filename, true);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return Modules;
        }
    }
}

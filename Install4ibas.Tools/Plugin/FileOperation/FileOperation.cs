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
        /// <summary>
        /// 复制资源文件
        /// </summary>
        /// <param name="Path">目标文件夹</param>
        public static void CopyResourceFiles(string Path)
        {
            var ResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            foreach (var ResourceName in ResourceNames.Where(c => c.StartsWith(WebFolderName)))
            {
                var fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName);
                if (fileStream == null) continue;
                var fileName = ResourceName.Replace(WebFolderName, "").Replace(".", @"\");
                fileName = fileName.Substring(0, fileName.LastIndexOf(@"\")) + "." + fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                if (fileName.Contains(@"\") && !Directory.Exists(System.IO.Path.Combine(Path, fileName.Substring(0, fileName.LastIndexOf(@"\")))))
                        Directory.CreateDirectory(System.IO.Path.Combine(Path, fileName.Substring(0, fileName.LastIndexOf(@"\"))));
                if (File.Exists(System.IO.Path.Combine(Path, fileName))) continue;
                StreamWriter sw = new StreamWriter(System.IO.Path.Combine(Path, fileName));
                fileStream.CopyTo(sw.BaseStream);
                sw.Flush();
                sw.Close();
            }
        }
        #region 运行批处理脚本
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
                Console.WriteLine("Exception Occurred :{0}运行失败,{1}，{2}", filename, ex.Message, ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// 执行命令行
        /// </summary>
        /// <param name="optionalFilePaths">命令</param>
        /// <returns>返回结果</returns>
        public static string ExecuteCmd(string[] optionalFilePaths)
        {
            //运行命令行
            Process p = new Process();
            // 设定程序名
            p.StartInfo.FileName = "cmd.exe";
            // 关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            // 重定向标准输入
            p.StartInfo.RedirectStandardInput = true;
            // 重定向标准输出
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            p.StartInfo.RedirectStandardError = true;
            // 设置不显示窗口
            p.StartInfo.CreateNoWindow = true;
            // 启动进程
            p.Start();
            for (int i = 0; i < optionalFilePaths.Length; i++)
            {
                p.StandardInput.WriteLine(optionalFilePaths[i]);
            }
            p.StandardInput.WriteLine("exit");
            // 从输出流获取命令执行结果
            string strRst = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            return strRst;
        }
        /// <summary>
        /// 执行命令行
        /// </summary>
        /// <param name="optionalFilePath">命令</param>
        /// <returns>optionalFilePaths</returns>
        public static string ExecuteCmd(string optionalFilePath)
        {
            string[] optionalFilePaths = new string[] { optionalFilePath };
            return ExecuteCmd(optionalFilePaths);
        }
        #endregion
        public static IList<ibasModule> CopyModules(string SourcePath, string InstallPath, IList<ibasModule> Modules)
        {
            if (Modules == null || Modules.Count == 0) return Modules;
            try
            {
                // 判断目标目录是否存在如果不存在则新建
                if (!System.IO.Directory.Exists(InstallPath))
                {
                    System.IO.Directory.CreateDirectory(InstallPath);
                }
                #region 基于文件目录
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（srcPath）；
                //string[] fileList = System.IO.Directory.GetFileSystemEntries(SourcePath);
                // 遍历所有的文件和目录
                //foreach (string file in fileList)
                //{
                //    if (System.IO.Directory.Exists(file))
                //    {
                //        continue;
                //    }
                //    string filename = Path.GetFileName(file);
                //    if (filename.StartsWith("ibas_4_modules_published") && filename.EndsWith("zip"))
                //    {

                //        string modulename = filename.Substring(filename.LastIndexOf("_BizSys") + 8, filename.Length - filename.LastIndexOf("_BizSys") - 12);
                //        var module = Modules.FirstOrDefault(c => c.ModuleName == modulename);
                //        if (module == null) continue;
                //        module.ModuleInstallPath = InstallPath + "\\" + filename;
                //        var packaddress = Path.Combine(InstallPath, "~packages");
                //        System.IO.File.Copy(file, packaddress, true);
                //    }
                //    else if (filename.StartsWith("ibas_4_shell_published") && filename.EndsWith("zip"))
                //    {
                //        var module = Modules.FirstOrDefault(c => c.ModuleName == "shell");
                //        if (module == null) continue;
                //        module.ModuleInstallPath = InstallPath + "\\" + filename;
                //        var packaddress=  Path.Combine(InstallPath, "~packages");
                //        System.IO.File.Copy(file, packaddress, true);
                //    }
                //}
                #endregion
                #region 基于模块列表
                foreach (var module in Modules.Where(c => c.Checked))
                {
                    if (File.Exists(Path.Combine(SourcePath, module.PackageFileName)))
                    {
                        module.ModuleInstallPath = InstallPath;
                        File.Copy(Path.Combine(SourcePath, module.PackageFileName), Path.Combine(InstallPath, module.PackageFileName));
                    }
                }
                #endregion
            }
            catch (Exception e)
            {
                throw;
            }
            return Modules;
        }
    }
}

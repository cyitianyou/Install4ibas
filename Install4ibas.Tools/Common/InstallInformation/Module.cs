using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Linq;

namespace Install4ibas.Tools.Common.InstallInformation
{

    [CollectionDataContract(Name = "ibasModules", Namespace = "http://ibas.club/install")]
    [KnownType(typeof(ibasModules))]
    [KnownType(typeof(ibasModule))]
    public class ibasModules : ObservableCollection<ibasModule>, IList<ibasModule>
    {
        public void GetLocalInfo(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath)) return;
                var list = FileModule.GetFileModules(folderPath);
                if (list == null) return;
                var modulesGroup = list.GroupBy(c => new { c.IsShell, c.ModuleName });
                if (modulesGroup == null) return;
                foreach (var group in modulesGroup)
                {
                    var ibas_Moudule = this.FirstOrDefault(c => (c.ModuleName == group.Key.ModuleName && c.Type != emModuleType.shell && !group.Key.IsShell)
                                                                                           || (c.Type == emModuleType.shell && group.Key.IsShell)
                                                                                   );
                    //当前集合没有该模块
                    if (ibas_Moudule == null)
                    {
                        ibas_Moudule = new ibasModule();
                        ibas_Moudule.Type = group.Key.IsShell ? emModuleType.shell : emModuleType.other;
                        ibas_Moudule.ModuleName = group.Key.ModuleName;
                        ibas_Moudule.ModuleDescription = group.Key.ModuleName;
                        this.Add(ibas_Moudule);
                    }
                    //添加模块包名列表
                    foreach (var item in group.OrderBy(c=>c.FileDate))
                    {
                        ibas_Moudule.PackageFileList.Insert(0, item.FileName);
                    }
                    //模块默认选中第一个包名
                    if (ibas_Moudule.PackageFileList.Count > 0)
                    {
                        ibas_Moudule.Checked = true;
                        ibas_Moudule.PackageFileName = ibas_Moudule.PackageFileList[0];
                    }
                }
            }
            catch(Exception)
            {
            }
        }
    }
    [DataContract(Namespace = "http://ibas.club/install")]
    public class ibasModule
    {
        const string DOWNLOAD = "联网下载";
        public ibasModule()
        {
            this.ModuleId = "";
            this.ModuleName = "";
            this.ModuleDescription = "";
            this.ModuleInstallPath = "";
            this.PackageFileName = "";
            this.PackageFileList = new MyList<string>();
            this.Type = emModuleType.all;
            this.Status = emInstallStatus.notInstalled;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ModuleId", Order = 1)]
        public String ModuleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ModuleName", Order = 2)]
        public String ModuleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ModuleDescription", Order = 3)]
        public String ModuleDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ModuleInstallPath", Order = 4)]
        public String ModuleInstallPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Type", Order = 5)]
        public emModuleType Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Status", Order = 6)]
        public emInstallStatus Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "PackageFilePath", Order = 7)]
        public string PackageFileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "PackageFileList", Order = 8)]
        public MyList<string> PackageFileList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Checked", Order = 9)]
        public bool Checked { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", this.Type, this.ModuleName, this.ModuleDescription);
        }

    }
    [CollectionDataContract(ItemName = "FilePath", Namespace = "http://ibas.club/install")]
    public class MyList<T> : List<T>
    {

    }

    public class FileModule
    {
        public bool IsShell { get; set; }
        public string ModuleName { get; set; }
        public string FileName { get; set; }
        public DateTime FileDate { get; set; }

        public static IEnumerable<FileModule> GetFileModules(string folderPath)
        {
            var list = new List<FileModule>();
            try
            {
                if (!Directory.Exists(folderPath)) throw new Exception("给定路径不是一个文件夹路径");
                var fileList = Directory.GetFiles(folderPath, "*.zip", SearchOption.TopDirectoryOnly);
                foreach (string filePath in fileList)
                {
                    var info=new FileInfo(filePath);
                    string file = info.Name;
                    if (!(file.StartsWith(@"ibas_4_") && file.EndsWith(".zip"))) continue;
                    var module = GetFileModule(file);
                    if (module != null)
                        list.Add(module);
                }
                return list;
            }
            catch (Exception)
            {
                return list;
            }

        }

        static FileModule GetFileModule(string fileName)
        {
            try
            {
                var module = new FileModule();
                module.FileName = fileName;
                if (fileName.StartsWith("ibas_4_modules_published_") && fileName.Contains("BizSys."))
                {
                    module.IsShell = false;
                    module.ModuleName = fileName.Substring(fileName.LastIndexOf("BizSys.") + 7).Replace(".zip", "");
                    var dateString = fileName.Substring(25, 15);
                    module.FileDate = DateTime.ParseExact(dateString, "yyyyMMdd_HHmmss", null);
                }
                else if (fileName.StartsWith("ibas_4_shell_published_"))
                {
                    module.IsShell = true;
                    module.ModuleName = "shell";
                    var dateString = fileName.Substring(23, 15);
                    module.FileDate = DateTime.ParseExact(dateString, "yyyyMMdd_HHmmss", null);
                }
                else throw new Exception("命名不符合规范");
                return module;
            }
            catch (Exception)
            {
                return null;
            }


        }
    }
}

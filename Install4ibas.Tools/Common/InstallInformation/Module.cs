using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Install4ibas.Tools.Common.InstallInformation
{

    [CollectionDataContract(Name = "ibasModules", Namespace = "http://ibas.club/install")]
    [KnownType(typeof(ibasModules))]
    [KnownType(typeof(ibasModule))]
    public class ibasModules : ObservableCollection<ibasModule>, IList<ibasModule>
    {

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
            this.PackageFilePath = "";
            this.PackageFileList = new MyList<string>();
            this.Type = emModuleType.all;
            this.Status = emInstallStatus.notInstalled;
        }
        [DataMember(Name = "ModuleId", Order = 1)]
        public String ModuleId { get; set; }
        [DataMember(Name = "ModuleName", Order = 2)]
        public String ModuleName { get; set; }
        [DataMember(Name = "ModuleDescription", Order = 3)]
        public String ModuleDescription { get; set; }
        [DataMember(Name = "ModuleInstallPath", Order = 4)]
        public String ModuleInstallPath { get; set; }
        [DataMember(Name = "Type", Order = 5)]
        public emModuleType Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
                if (_Type == emModuleType.basic
                    || _Type == emModuleType.shell
                    || _Type == emModuleType.standard)
                {
                    if (PackageFileList == null) PackageFileList = new MyList<string>();
                    if (!PackageFileList.Contains(DOWNLOAD))
                        PackageFileList.Add(DOWNLOAD);
                }
            }
        }
        private emModuleType _Type;
        [DataMember(Name = "Status", Order = 6)]
        public emInstallStatus Status { get; set; }
        [DataMember(Name = "PackageFilePath", Order = 7)]
        public string PackageFilePath { get; set; }
        [DataMember(Name = "PackageFileList", Order = 8)]
        public MyList<string> PackageFileList { get; set; }
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
}

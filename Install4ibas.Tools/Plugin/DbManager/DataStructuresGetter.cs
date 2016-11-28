using Install4ibas.Tools.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.DbManager
{
    class DataStructuresGetter
    {
        public string WorkFolder
        {
            set;
            get;
        }

        public const string SIGN_DATA_STRUCTURE_HEADER = "DS_";
        public const string SIGN_B1_DATA_STRUCTURE_HEADER = "DS_B1";
        public const string SIGN_DATA_STRUCTURE_END = ".XML";
        public const string SIGN_SQL_SCRIPT_END = ".SQL";

        public IList<DataStructureItem> Get()
        {
            var dsItems = this.GetItems(this.WorkFolder);
            dsItems = this.SortItems(dsItems);
            return dsItems;
        }

        IList<DataStructureItem> GetItems(string folder)
        {
            var dsItems = new List<DataStructureItem>();
            if (!System.IO.Directory.Exists(folder)) return dsItems;
            foreach (var item in System.IO.Directory.GetFiles(folder))
            {
                var fileName = System.IO.Path.GetFileName(item);
                var group = System.IO.Path.GetDirectoryName(item).Replace(this.WorkFolder, "");
                group += @"\";
                if (fileName.StartsWith(SIGN_DATA_STRUCTURE_HEADER, StringComparison.InvariantCultureIgnoreCase)
                    && fileName.EndsWith(SIGN_DATA_STRUCTURE_END, StringComparison.InvariantCultureIgnoreCase)
                    )
                {
                    // 数据结构项目
                    var platform = fileName.StartsWith(SIGN_B1_DATA_STRUCTURE_HEADER, StringComparison.InvariantCultureIgnoreCase) ? emPlatform.b1 : emPlatform.ibas;
                    var itemtype = emDSItemType.data_structure;

                    var dsItem = DataStructureItem.New(platform, itemtype, item, group);
                    dsItems.Add(dsItem);
                }
                if (fileName.EndsWith(SIGN_SQL_SCRIPT_END, StringComparison.InvariantCultureIgnoreCase))
                {
                    // 数据库脚本项目
                    var platform = emPlatform.ibas;
                    var itemtype = emDSItemType.sql_script;
                    var dsItem = DataStructureItem.New(platform, itemtype, item, group);
                    dsItems.Add(dsItem);
                }
            }
            foreach (var item in System.IO.Directory.GetDirectories(folder))
            {
                dsItems.AddRange(this.GetItems(item));
            }
            return dsItems;
        }

        IList<DataStructureItem> SortItems(IList<DataStructureItem> dsItems)
        {
            var dsItemsALL = new List<DataStructureItem>();
            #region 环境准备脚本
            var initScripts = dsItems.Where(c => c.FileName.IndexOf("prepare_environment_scripts", StringComparison.InvariantCultureIgnoreCase) >= 0);
            dsItemsALL.AddRange(initScripts);
            dsItems = dsItems.Where(c => !dsItemsALL.Contains(c)).ToList();
            #endregion
            #region 组内执行排序
            #region 脚本排序方法
            Func<IEnumerable<DataStructureItem>, IEnumerable<DataStructureItem>> orderScripts = (IEnumerable<DataStructureItem> tmps) =>
            {
                var scripts = new List<DataStructureItem>();
                //先初始化脚本
                scripts.AddRange(tmps.Where(c => c.FileName.IndexOf("Initialization", StringComparison.InvariantCultureIgnoreCase) >= 0));
                //模块注册脚本
                scripts.AddRange(tmps.Where(c => c.FileName.IndexOf("RegisteModules", StringComparison.InvariantCultureIgnoreCase) >= 0));
                ////不是B1组的
                //scripts.AddRange(tmps.Where(c => c.Group.IndexOf("B1", StringComparison.InvariantCultureIgnoreCase) < 0));
                //其他脚本
                scripts.AddRange(tmps.Where(c => !scripts.Contains(c)));
                return scripts;
            };
            #endregion

            var tmpGroups = dsItems.GroupBy(c => c.Group.Split('\\').Count() > 1 ? c.Group.Split('\\')[1] : c.Group.Split('\\')[0]).ToList();
            var groups = tmpGroups.Where(c => string.Equals(c.Key, "SystemCenter", StringComparison.InvariantCultureIgnoreCase)).ToList();
            groups.AddRange(tmpGroups.Where(c => tmpGroups.Contains(c)));
            foreach (var item in groups)
            {
                #region basis
                var tmps = item.Where(c => c.Group.IndexOf(@"\basis\", StringComparison.InvariantCultureIgnoreCase) >= 0);
                //加入数据结构
                var tmps2 = tmps.Where(c => c.ItemType == emDSItemType.data_structure);
                dsItemsALL.AddRange(tmps2);
                //加入脚本
                tmps2 = orderScripts(tmps.Where(c => c.ItemType == emDSItemType.sql_script));
                dsItemsALL.AddRange(tmps2);
                #endregion
                #region system
                tmps = item.Where(c => c.Group.IndexOf(@"\system\", StringComparison.InvariantCultureIgnoreCase) >= 0);
                //加入数据结构
                tmps2 = tmps.Where(c => c.ItemType == emDSItemType.data_structure);
                dsItemsALL.AddRange(tmps2);
                //加入脚本
                tmps2 = orderScripts(tmps.Where(c => c.ItemType == emDSItemType.sql_script));
                dsItemsALL.AddRange(tmps2);
                #endregion
                #region others
                //没有处理过的
                tmps = item.Where(c => !dsItemsALL.Contains(c));
                //加入数据结构
                tmps2 = tmps.Where(c => c.ItemType == emDSItemType.data_structure);
                dsItemsALL.AddRange(tmps2);
                //加入脚本
                tmps2 = orderScripts(tmps.Where(c => c.ItemType == emDSItemType.sql_script));
                dsItemsALL.AddRange(tmps2);
                #endregion
            }
            #endregion
            return dsItemsALL;
        }

        /// <summary>
        /// 自动选择项目
        /// </summary>
        /// <param name="isB1">b1平台</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public IList<DataStructureItem> GetSelecteds(bool isB1, emDatabaseType dbType)
        {
            var dsItems = this.Get();
            return this.AutoSelected(isB1, dbType, dsItems);
        }

        /// <summary>
        /// 自动选择项目
        /// </summary>
        /// <param name="isB1">b1平台</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="dsItems">待选择的项目</param>
        /// <returns></returns>
        public IList<DataStructureItem> AutoSelected(bool isB1, emDatabaseType dbType, IList<DataStructureItem> dsItems)
        {
            if (dsItems == null) return dsItems;
            //清理历史选择
            foreach (var item in dsItems)
            {
                item.Selected = false;
            }
            dsItems = dsItems.Where(c => c.FileName.IndexOf(".manual.", StringComparison.InvariantCultureIgnoreCase) < 0).ToList();//手工选择项，不自动选择。
            var b1List = new List<string>();//B1组
            if (isB1)
            {
                //先选择 b1 平台结构
                foreach (var item in dsItems)
                {
                    if (item.Platform ==emPlatform.ibas)
                    {
                        if (item.Group.IndexOf(@"\B1", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            //仅选择B1文件夹中
                            //ibas平台项目
                            if (item.ItemType ==emDSItemType.data_structure)
                            {
                                //数据项目
                                item.Selected = true;
                                if (!b1List.Contains(item.Group))
                                    b1List.Add(item.Group);
                            }
                            if (item.ItemType == emDSItemType.sql_script)
                            {
                                //脚本项目
                                if (item.DatabaseType == dbType
                                    || item.DatabaseType == emDatabaseType.all)
                                    item.Selected = true;
                                if (!b1List.Contains(item.Group))
                                    b1List.Add(item.Group);
                            }
                        }
                    }
                }
            }
            //选择其他结构
            foreach (var item in dsItems)
            {
                if (item.ItemType ==emDSItemType.data_structure)
                {
                    //数据结构
                    if (item.Platform == emPlatform.b1)
                        if (isB1)
                            item.Selected = true;
                    if (item.Platform == emPlatform.ibas)
                    {
                        if (item.Group.IndexOf(@"\B1", StringComparison.InvariantCultureIgnoreCase) >= 0) continue;//b1文件夹不做处理
                        var tmpItem = b1List.FirstOrDefault(c => c.IndexOf(item.Group) >= 0
                                || (c.IndexOf(item.Group) < 0 && string.Equals(this.GetGroupName(c), this.GetGroupName(item.Group), StringComparison.InvariantCultureIgnoreCase))
                            );
                        if (tmpItem == null)
                            item.Selected = true;
                    }
                }
                if (item.ItemType == emDSItemType.sql_script)
                {
                    //脚本
                    if (item.Platform == emPlatform.b1)
                        if (isB1)
                            if (item.DatabaseType == dbType
                                    || item.DatabaseType == emDatabaseType.all)
                                item.Selected = true;
                    if (item.Platform == emPlatform.ibas)
                    {
                        if (item.Group.IndexOf(@"\B1", StringComparison.InvariantCultureIgnoreCase) >= 0) continue;//b1文件夹不做处理
                        //var tmpItem = b1List.FirstOrDefault(c => c.IndexOf(item.Group) >= 0
                        //        || (c.IndexOf(item.Group) < 0 && string.Equals(this.GetGroupName(c), this.GetGroupName(item.Group), StringComparison.InvariantCultureIgnoreCase))
                        //    );
                        //if (tmpItem == null)
                        if (item.DatabaseType == dbType
                                || item.DatabaseType == emDatabaseType.all)
                            item.Selected = true;
                    }
                }
            }
            return dsItems;
        }

        string GetGroupName(string fullName)
        {
            int lastIndex = fullName.LastIndexOf(@"\");
            var tmp = fullName.Substring(0, lastIndex);
            int plastIndex = tmp.LastIndexOf(@"\");
            return fullName.Substring(plastIndex + 1, lastIndex - plastIndex - 1);
        }
    }
}

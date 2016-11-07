using Install4ibas.Tools.Common.InstallInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis.Step
{
    public class InstallStepManager
    {
        public AppSetting AppSetting { get; set; }
        IEnumerable<IInstallStep> _StepMaps;
        public IEnumerable<IInstallStep> StepMaps
        {
            get
            {
                if(_StepMaps==null)
                {
                    _StepMaps = this.GetInstances<IInstallStep>();
                }
                return _StepMaps;
            }
        }
        public void SetAppSetting (AppSetting Setting)
        {
            this.AppSetting = Setting;
        }

        public IInstallStep GetInstallStep(string Code)
        {
            try
            {
                var step= this.StepMaps.FirstOrDefault(c => c.StepCode == Code);
                if (step == null) throw new Exception("未找到指定的安装步骤。");
                step.AppSetting = this.AppSetting;
                return step;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取已加载的程序集，所有继承了类型的实例
        /// </summary>
        /// <typeparam name="T">获取实例的类型</typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetInstances<T>()
        {
            var objects = new List<T>();
            foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                var name = assembly.ManifestModule.ToString();
                if (!name.Contains(".Step.")) continue;
                try
                {
                    foreach (var item in assembly.GetExportedTypes())
                    {
                        if (!item.IsClass) continue;
                        if (item.IsInterface) continue;
                        if (item.IsImport) continue;
                        if (item.IsGenericType) continue;
                        if (!item.IsSubclassOf(typeof(T))) continue;
                        try
                        {
                            T obj = (T)Activator.CreateInstance(item);
                            if (obj != null)
                                objects.Add(obj);
                        }
                        catch (System.Exception)
                        {
                            continue;
                        }
                    }
                }
                catch (System.Exception)
                {

                }
            }
            return objects;
        }
    }
}

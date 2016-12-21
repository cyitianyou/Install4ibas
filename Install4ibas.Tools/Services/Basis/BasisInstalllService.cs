using Install4ibas.Tools.Core;
using Install4ibas.Tools.Services.Basis.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis
{
    public abstract class BasisInstalllService : IInstallService
    {
        #region 初始化及属性
        public BasisInstalllService()
        {
            this._AppSetting = new AppSetting();
        }
        const string SERVICECODE = "Basis";
        public virtual string ServiceCode
        {
            get { return SERVICECODE; }
        }
        AppSetting _AppSetting;
        public AppSetting AppSetting
        {
            get
            {
                if (_AppSetting == null)
                    _AppSetting = new AppSetting();
                return _AppSetting;
            }
        }
        InstallStepManager _StepManager;
        public InstallStepManager StepManager
        {
            get
            {
                if (_StepManager == null)
                    _StepManager = new InstallStepManager();
                return _StepManager;
            }
        }

        public Plugin.MessageManager MessageManager
        {
            get
            {
                return Plugin.MessageManager.Instance;
            }
            set
            {
                Plugin.MessageManager.Instance = value;
            }
        }
        #endregion
        public bool Excute(bool isFirstRun = true)
        {
            if (isFirstRun)
                this.BeforeExcute();
            try
            {
                foreach (var item in this.AppSetting.Steps)
                {
                    //循环方案步骤
                    if (!item.Completed)
                    {
                        try
                        {
                            this.ExecutingStep(item);//运行步骤
                            this.ExecutingStepDone(item);//执行完成
                        }
                        catch (Exception error)
                        {
                            throw new Exception(string.Format("步骤[{0} - {1}]执行失败，错误信息：[{2}]", item.StepCode, item.StepName,error.Message),error);
                        }
                    }
                }
                //安装完成
                return true;
            }
            catch (Exception error)
            {
                var args = new Core.ServiceEventArgs();
                args.Error = error;
                this.MessageManager.OnWriteFileLog(this, args);//写入日志文件
                throw error;
            }
        }

        protected virtual void ExecutingStep(InstallInformationStep step)
        {
            try
            {
                var installStep = this.StepManager.GetInstallStep(step.StepCode);
                var args = new Core.ServiceEventArgs(string.Format("正在执行步骤[{0}]", step.StepName));
                this.MessageManager.OnUpdateInstallationSchedule(this, args);//更新界面进度
                this.MessageManager.OnWriteFileLog(this, args);//写入日志文件
                installStep.Excute();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        protected virtual void ExecutingStepDone(InstallInformationStep step)
        {
            step.Completed = true;
            var total = this.AppSetting.Steps.Count;
            var index = this.AppSetting.Steps.IndexOf(step);
            if (index > -1)
            {
                var args = new Core.ServiceEventArgs();
                args.ScheduleValue = (index + 1) * 100 / total;
                args.Message = string.Format("执行步骤[{0}]完成", step.StepName);
                args.MessageType = Plugin.Messages.emMessageType.success;
                this.MessageManager.OnUpdateInstallationSchedule(this, args);//更新界面进度
                this.MessageManager.OnWriteFileLog(this, args);//写入日志文件
            }
        }


        /// <summary>
        /// 检查我的初始化状态
        /// </summary>
        protected virtual void CheckMyInitializedStatus()
        {
            if (this._AppSetting == null)
                throw new Exception("尚未初始化设置。");
        }
        protected virtual void BeforeExcute()
        {
            this.CheckMyInitializedStatus();
            var information = this.GetPresetInstallInformation();
            if (information != null)
                this.AppSetting.Steps = information.Steps;
            this.StepManager.SetAppSetting(this.AppSetting);
        }
        /// <summary>
        /// 获取预设的安装信息
        /// </summary>
        /// <returns></returns>
        protected virtual AppSetting GetPresetInstallInformation()
        {
            try
            {
                var myAssembly = this.GetType().Assembly;
                var myNamespace = this.GetType().Namespace;
                System.IO.Stream setStream = null;
                foreach (var item in myAssembly.GetManifestResourceNames())
                {
                    if (item.IndexOf(myNamespace) < 0) continue;
                    if (!item.EndsWith("InstallSteps.xml", StringComparison.InvariantCultureIgnoreCase)) continue;
                    setStream = myAssembly.GetManifestResourceStream(item);
                    break;
                }
                if (setStream == null)
                    return null;// throw new Exception(string.Format("没有找到预置文件资源。", ""));
                var knownTypes = new List<Type>() { typeof(AppSetting), typeof(InstallInformationStep) };
                var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(AppSetting), knownTypes);
                var information = serializer.ReadObject(setStream) as AppSetting;
                if (information == null)
                    throw new Exception("预置方案配置不是有效的数据。");
                setStream.Close();
                return information;
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("获取预置方案失败，{0}", error.Message), error);
            }
        }





    }
}

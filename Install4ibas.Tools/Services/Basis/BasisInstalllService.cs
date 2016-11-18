using Install4ibas.Tools.Common.InstallInformation;
using Install4ibas.Tools.Services.Basis.Step;
using Install4ibas.Tools.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis
{
    public abstract class BasisInstalllService : IInstallService
    {
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

        public bool Excute()
        {
            this.BeforeExcute();
            try
            {
                foreach (var item in this.AppSetting.Steps)
                {
                    //循环方案步骤
                    var executed = false;
                    if (!item.Completed)
                    {
                        //步骤没有完成
                        executed = this.ExecutingStep(item);//运行步骤
                        if (executed)
                            this.ExecutingStepDone(item);//执行完成
                        else
                            throw new Exception(string.Format("步骤[{0} - {1}]执行返回失败，运行终止。", item.StepCode, item.StepName));
                    }
                }
                //安装完成
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        protected virtual bool ExecutingStep(InstallInformationStep step)
        {
            try
            {
                var installStep = this.StepManager.GetInstallStep(step.StepCode);
                installStep.UpdateInstallationScheduleEvent += OnUpdateInstallationSchedule;
                var args = new Common.ServiceEventArgs(string.Format("正在执行步骤[{0}]", step.StepName));
                OnUpdateInstallationSchedule(this, args);
                installStep.Excute();
                installStep.UpdateInstallationScheduleEvent -= OnUpdateInstallationSchedule;
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        protected virtual void ExecutingStepDone(InstallInformationStep step)
        {
            step.Completed = true;
            var total = this.AppSetting.Steps.Count;
            var index = this.AppSetting.Steps.IndexOf(step);
            if (index > 0)
            {
                var args = new Common.ServiceEventArgs();
                args.ScheduleValue = (index + 1) * 100 / total;
                args.Message=string.Format("执行步骤[{0}]完成",step.StepName);
                OnUpdateInstallationSchedule(this, args);
            }
        }


        public event Common.ServiceEventHandle UpdateInstallationScheduleEvent;
        private void OnUpdateInstallationSchedule(object sender, ServiceEventArgs args)
        {
            if (this.UpdateInstallationScheduleEvent != null)
            {
                this.UpdateInstallationScheduleEvent.Invoke(sender, args);
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

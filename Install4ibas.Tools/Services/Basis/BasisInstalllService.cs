using Install4ibas.Tools.Common.InstallInformation;
using Install4ibas.Tools.Services.Basis.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services.Basis
{
    public abstract class BasisInstalllService : IInstallService
    {
        InstallInformation _AppSetting;
        public InstallInformation AppSetting
        {
            get
            {
                if (_AppSetting == null)
                    _AppSetting = new InstallInformation();
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
                installStep.Excute();
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
            if (this.UpdateInstallationScheduleEvent != null)
            {
                var args = new Common.ServiceEventArgs();
                this.UpdateInstallationScheduleEvent.Invoke(this, args);
            }
        }


        public event Common.ServiceEventHandle UpdateInstallationScheduleEvent;

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
        protected virtual InstallInformation GetPresetInstallInformation()
        {
            try
            {
                var myAssembly = this.GetType().Assembly;
                var myNamespace = this.GetType().Namespace;
                System.IO.Stream setStream = null;
                foreach (var item in myAssembly.GetManifestResourceNames())
                {
                    if (item.IndexOf(myNamespace) < 0) continue;
                    if (!item.EndsWith("InstallInformationSteps.xml", StringComparison.InvariantCultureIgnoreCase)) continue;
                    setStream = myAssembly.GetManifestResourceStream(item);
                }
                if (setStream == null)
                    return null;// throw new Exception(string.Format("没有找到预置文件资源。", ""));
                var knownTypes = new List<Type>() { typeof(InstallInformation), typeof(InstallInformationStep) };
                var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(InstallInformation), knownTypes);
                var information = serializer.ReadObject(setStream) as InstallInformation;
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

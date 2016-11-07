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
        /// <summary>
        /// 检查我的初始化状态
        /// </summary>
        protected virtual void CheckMyInitializedStatus()
        {
            if (this._AppSetting == null)
                throw new Exception("尚未初始化设置。");
        }
        public bool Excute()
        {
            this.CheckMyInitializedStatus();
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
                    }
                    if (!executed)//步骤运行没有返回正确的值，终止方案运行
                        throw new Exception(string.Format("步骤[{0} - {1}]执行返回失败，运行终止。", item.StepCode, item.StepName));
                }
                //安装完成
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        protected abstract bool ExecutingStep(InstallInformationStep step);


        public event Common.ServiceEventHandle UpdateInstallationScheduleEvent;
    }
}

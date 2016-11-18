using System;

namespace Install4ibas.Tools.Services.Common
{
    public class ServiceEventArgs : EventArgs
    {
        #region 构造函数
        public ServiceEventArgs()
        { 
        }
        public ServiceEventArgs(int scheduleValue, string message)
        {
            this.ScheduleValue = scheduleValue;
            this.Message = Message;
        }
        public ServiceEventArgs(string message)
        {
            this.Message = Message;
        }
        #endregion
        public int ScheduleValue { get; set; }
        public string Message { get; set; }
    }
}

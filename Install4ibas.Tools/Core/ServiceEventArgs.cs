using System;

namespace Install4ibas.Tools.Services.Core
{
    public class ServiceEventArgs : EventArgs
    {
        #region 构造函数
        public ServiceEventArgs()
        {
        }
        public ServiceEventArgs(string message, int scheduleValue = 0, Exception error = null)
        {
            this.Message = message;
            this.ScheduleValue = scheduleValue;
            this.Error = error;
        }
        #endregion
        public int ScheduleValue { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }
    }
}

using Install4ibas.Tools.Plugin.Messages;
using System;

namespace Install4ibas.Tools.Core
{
    public class ServiceEventArgs : EventArgs
    {
        #region 构造函数
        public ServiceEventArgs()
        {
        }
        public ServiceEventArgs(Exception error)
        {
            this.Error = error;
        }
        public ServiceEventArgs(string message, int scheduleValue = 0, Exception error = null)
        {
            this.Message = message;
            this.ScheduleValue = scheduleValue;
            this.Error = error;
            this.MessageType = emMessageType.success;
        }
        #endregion
        public int ScheduleValue { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }

        public EventType EventType { get; set; }
        public emMessageType MessageType { get; set; }
    }

    public enum EventType
    {
        UpdateInstallationSchedule,
        WriteMessageLog,
        WriteFileLog
    }
}

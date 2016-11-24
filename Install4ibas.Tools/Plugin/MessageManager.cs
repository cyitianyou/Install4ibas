﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Install4ibas.Tools.Core;

namespace Install4ibas.Tools.Plugin
{
    public class MessageManager
    {
        static MessageManager _Instance;
        public static MessageManager Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new MessageManager();
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        public event ServiceEventHandle UpdateInstallationScheduleEvent;
        public void OnUpdateInstallationSchedule(object sender, ServiceEventArgs e)
        {
            if (UpdateInstallationScheduleEvent != null)
                this.UpdateInstallationScheduleEvent.Invoke(sender, e);
        }

        public event ServiceEventHandle WriteMessageLogEvent;
        public void OnWriteMessageLog(object sender, ServiceEventArgs e)
        {
            if (WriteMessageLogEvent != null)
                this.WriteMessageLogEvent.Invoke(sender, e);
        }

        public event ServiceEventHandle WriteFileLogEvent;
        public void OnWriteFileLog(object sender, ServiceEventArgs e)
        {
            if (WriteFileLogEvent != null)
                this.WriteFileLogEvent.Invoke(sender, e);
        }
    }
}

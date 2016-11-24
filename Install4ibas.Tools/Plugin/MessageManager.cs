using System;
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

        event ServiceEventHandle UpdateInstallationScheduleEvent;

    }
}

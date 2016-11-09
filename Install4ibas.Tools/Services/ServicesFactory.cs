using Install4ibas.Tools.Services.AppendInstall;
using Install4ibas.Tools.Services.Basis;
using Install4ibas.Tools.Services.NewInstall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Services
{
    public class ServicesFactory
    {
        static ServicesFactory _Instance;

        public static ServicesFactory New()
        {
            if (_Instance == null)
            {
                _Instance = new ServicesFactory();
            }
            return _Instance;
        }
        public IInstallService GetService(string ServiceCode)
        {
            IInstallService service = null;
            switch (ServiceCode)
            {
                case NewInstallService.SERVICECODE:
                    service = new NewInstallService();
                    break;
                case AppendInstallService.SERVICECODE:
                    service = new AppendInstallService();
                    break;
                default:
                    break;
            }
            return service;
        }
    }
}

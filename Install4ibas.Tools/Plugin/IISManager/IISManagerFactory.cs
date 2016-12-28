using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install4ibas.Tools.Plugin.IISManager
{
    public class IISManagerFactory
    {
        static IISManagerFactory _Instance;

        public static IISManagerFactory New()
        {
            if (_Instance == null)
            {
                _Instance = new IISManagerFactory();
            }
            return _Instance;
        }
        //static IIISManager IISManager;
        public IIISManager CreateIISManager()
        {
            //if (IISManager == null)
            //{
            var IISManager = new IISManager();
            //}
            return IISManager;
        }

        //static IIISInstaller IISInstaller;
        public IIISInstaller CreateIISInstaller()
        {
            //if (IISInstaller == null)
            //{
            var IISInstaller = new IISInstaller();
            //}
            return IISInstaller;
        }
    }
}

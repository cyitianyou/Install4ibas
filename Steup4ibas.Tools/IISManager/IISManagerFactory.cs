using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steup4ibas.Tools.IISManager
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

        public IIISManager CreateIISManager()
        {
            IIISManager IISManager = null;
            IISManager = new IISManager();
            return IISManager;
        }
    }
}

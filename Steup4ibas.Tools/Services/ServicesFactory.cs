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
    }
}

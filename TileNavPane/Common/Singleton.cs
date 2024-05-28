using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileNavPane.Common;

namespace TileNavPane
{
    public sealed class Singleton
    {
   
        static Singleton _instance;
     
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }
        public OM_SESION Session { get; set; }
        

  

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileNavPane.Model
{
    public class Ordenes
    {
        public int ID_ORDEN { get; set; }

        public int ID_PEDIDOS { get; set; }

        public int ID_PRODUCTO { get; set; }

        public int CANTIDAD { get; set; }
        
        public bool CON_TODO { get; set; }

        public string CON_TODO_MENOS { get; set; }
    }
}

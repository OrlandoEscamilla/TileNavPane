using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileNavPane.Model
{
    public class OperacionHttpEscPos
    {
        public string nombre { get; set; }
        public List<object> argumentos { get; set; }

        public OperacionHttpEscPos(string nombre, List<object> argumentos)
        {
            this.nombre = nombre;
            this.argumentos = argumentos;
        }
    }
}

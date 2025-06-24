using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileNavPane.Model
{
    public class Pedidos
    {

        public Pedidos() { }
      

        public int ID_PEDIDO { get; set; }

        public DateTime FECHA_HORA { get; set; }

        public string ESTATUS { get; set; }

        public bool PARA_LLEVAR { get; set; }

        public string NOMBRE_CLIENTE { get; set; }

        public string TELEFONO_CLIENTE { get; set; }

        public string COMENTARIOS { get; set; }

        public int TOTAL { get; set; }

        public string USUARIO_CAPTURA { get; set; }

        public ObservableCollection<Ordenes> Ordenes { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileNavPane.Model
{
    public class ImpresionConNombrePluginV3
    {
        public List<OperacionHttpEscPos> operaciones { get; set; }
        public string nombreImpresora { get; set; }
        public string serial { get; set; }

        public ImpresionConNombrePluginV3(List<OperacionHttpEscPos> operaciones, string nombreImpresora, string serial)
        {
            this.operaciones = operaciones;
            this.nombreImpresora = nombreImpresora;
            this.serial = serial;
        }
    }
}

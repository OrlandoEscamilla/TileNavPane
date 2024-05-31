using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileNavPane.Model;
using static TileNavPane.Data.DataSet1;

namespace TileNavPane.ViewModel
{
    public class tablePedidosVM : DevExpress.Mvvm.ViewModelBase
    {


        public tablePedidosVM() {
            InitializeData();
        }

        public List<Pedidos> DataSource
        {
            get { return GetProperty(() => DataSource); }
            set { SetProperty(() => DataSource, value); }
        }


        private void InitializeData()
        {
            using (Data.DataSet1TableAdapters.TA_PEDIDOS ta = new Data.DataSet1TableAdapters.TA_PEDIDOS())
            {
                Data.DataSet1.DT_PEDIDOSDataTable dt = new Data.DataSet1.DT_PEDIDOSDataTable();
                dt = ta.GetData();

                List<Pedidos> listPedidos = new List<Pedidos>();

                foreach (DT_PEDIDOSRow row in dt.Rows )
                {
                    Pedidos objPedido = new Pedidos()
                    {
                        ID_PEDIDO = row.ID_PEDIDO,
                        FECHA_HORA = row.FECHA_HORA,
                        ESTATUS = row.ESTATUS,
                        PARA_LLEVAR = row.PARA_LLEVAR,
                        NOMBRE_CLIENTE = row.NOMBRE_CLIENTE,
                        TELEFONO_CLIENTE = row.TELEFONO_CLIENTE,
                        COMENTARIOS = row.COMENTARIOS,
                        TOTAL = row.TOTAL
                    };

                    listPedidos.Add(objPedido);
                }
                DataSource = listPedidos;
            }

        }
        
    }
}

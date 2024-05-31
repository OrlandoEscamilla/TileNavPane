using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileNavPane.ViewModel
{
    public class OrdenVM : DevExpress.Mvvm.ViewModelBase
    {
        public OrdenVM() {
            listIngredientes = new List<string> { "Cebolla", "Cilantro", "Crema", "Aguacate", "Queso" };

        }




        public List<string> listIngredientes
        {
            get { return GetProperty(() => listIngredientes); }
            set { SetProperty(() => listIngredientes, value); }
        }

        public int ID_PRODUCTO
        {
            get { return GetProperty(() => ID_PRODUCTO); }
            set { SetProperty(() => ID_PRODUCTO, value); }
        }

        public int ID_PEDIDO
        {
            get { return GetProperty(() => ID_PEDIDO); }
            set { SetProperty(() => ID_PEDIDO, value); }
        }

        public int CANTIDAD
        {
            get { return GetProperty(() => CANTIDAD); }
            set { SetProperty(() => CANTIDAD, value); }
        }

        public bool CON_TODO
        {
            get { return GetProperty(() => CON_TODO); }
            set { SetProperty(() => CON_TODO, value); }
        }

        public string CON_TODO_MENOS
        {
            get { return GetProperty(() => CON_TODO_MENOS);}
            set { SetProperty(() => CON_TODO_MENOS, value);}
       
        }

    }
}

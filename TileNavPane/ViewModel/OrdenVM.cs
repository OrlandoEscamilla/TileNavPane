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
        listIngredientes = new List<string> {"Cebolla", "Cilantro", "Crema", "Aguacate", "Queso" };
        
        }




        public List<string> listIngredientes
        {
            get { return GetProperty(() => listIngredientes); }
            set { SetProperty(() => listIngredientes, value); }
        }

    }
}

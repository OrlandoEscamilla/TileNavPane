using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows.Input;
using TileNavPane.View;
using TileNavPane.ViewModel;


namespace TileNavPane
{
    public class MainWindowVM : DevExpress.Mvvm.ViewModelBase
    {
        ICommand _abrir;

        protected IDialogService OrdenDlg { get { return this.GetService<IDialogService>("OrdenDlg"); } }


        public ICommand Abrir
        {
            get { 
                return _abrir ?? (_abrir = new DevExpress.Mvvm.DelegateCommand(() => {
                    OrdenVM objOrden = new OrdenVM();

                    OrdenDlg.ShowDialog(null, "Actualizar Registro", objOrden);

                  
                }));
            }
        }




    }
}

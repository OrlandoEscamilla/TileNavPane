using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows.Input;
using TileNavPane.View;
using TileNavPane.ViewModel;
using System.Windows.Controls;


namespace TileNavPane
{
    public class MainWindowVM : DevExpress.Mvvm.ViewModelBase
    {


        ICommand _inicio;
        ICommand _abrir;
        ICommand _pedidos;
        ICommand _cobro;

        protected IDialogService OrdenDlg { get { return this.GetService<IDialogService>("OrdenDlg"); } }



        public MainWindowVM()
        {
            CurrentView = new UserControlImagenPrincipal();
        }


        public object CurrentView
        {
            get { return GetProperty(() => CurrentView); }
            set{ SetProperty(() => CurrentView, value); }
        }



        public ICommand Inicio
        {
            get
            {
                return _inicio ?? (_inicio = new DevExpress.Mvvm.DelegateCommand(() => {
                    CurrentView = new UserControlImagenPrincipal();
                }));
            }
        }





        public ICommand Abrir
        {
            get { 
                return _abrir ?? (_abrir = new DevExpress.Mvvm.DelegateCommand(() => {
                    OrdenVM objOrden = new OrdenVM();

                      //UICommand aceptarCommand = new UICommand()
                      // {
                      //     Caption = "Aceptar",
                      //     IsCancel = false,
                      //     IsDefault = true,
                      //     Command = new DevExpress.Mvvm.DelegateCommand(() =>
                      //     {

                      //     })
                      // };

                      // UICommand cancelCommand = new UICommand()
                      // {
                      //     Caption = "Cancelar",
                      //     IsCancel = true,
                      //     IsDefault = false
                      // };

                    OrdenDlg.ShowDialog(/*new List<UICommand>() {aceptarCommand, cancelCommand }*/null, "Crear Pedido", objOrden);

                    tablePedidos view = new tablePedidos();
                    tablePedidosVM context = new tablePedidosVM();

                    view.DataContext = context;
                    CurrentView = view;

                }));
            }
        }



        public ICommand Pedidos
        {
            get
            {
                return _pedidos ?? (_pedidos = new DevExpress.Mvvm.DelegateCommand(() =>
                {              
                    tablePedidos view = new tablePedidos();
                    tablePedidosVM context = new tablePedidosVM();
                   
                    view.DataContext = context;
                    CurrentView = view;                   
                }));
            }
        }

        public ICommand Cobro
        {
            get
            {
                return _cobro ?? (_cobro = new DevExpress.Mvvm.DelegateCommand(() =>
                {
                    Cobro view = new Cobro();
                    CobroVM context = new CobroVM();

                    view.DataContext = context;
                    CurrentView = view;
                }));
            }
        }


    }
}

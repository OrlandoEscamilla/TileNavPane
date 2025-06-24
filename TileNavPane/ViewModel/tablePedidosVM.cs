using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TileNavPane.Data.DataSet1TableAdapters;
using TileNavPane.Model;
using TileNavPane.View;
using static TileNavPane.Data.DataSet1;

namespace TileNavPane.ViewModel
{
    public class tablePedidosVM : DevExpress.Mvvm.ViewModelBase
    {

        ICommand _refrescarPedidosCommand;
        ICommand _enProcesoCommand;
        ICommand _terminarPedidoCommand;
        ICommand _cancelarPedidoCommand;
        ICommand _editarPedidoCommand;



        public IMessageBoxService Alertas { get { return GetService<IMessageBoxService>("AlertaDlg"); } }
        protected IDialogService OrdenDlg { get { return this.GetService<IDialogService>("OrdenDlg"); } }


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
                        USUARIO_CAPTURA = row.NOMBRE_USUARIO_CAPTURA,
                        FECHA_HORA = row.FECHA_HORA,
                        ESTATUS = row.ESTATUS,
                        PARA_LLEVAR = row.PARA_LLEVAR,
                        NOMBRE_CLIENTE = row.NOMBRE_CLIENTE,
                        TELEFONO_CLIENTE = row.TELEFONO_CLIENTE,
                        COMENTARIOS = row.COMENTARIOS,
                        TOTAL = row.TOTAL,
                        Ordenes = obtenerOrdenes(row.ID_PEDIDO)
                    };

                    listPedidos.Add(objPedido);

                }
                DataSource = listPedidos;
            }

        }

        public ObservableCollection<Ordenes> obtenerOrdenes(int idPedido)
        {
            using (Data.DataSet1TableAdapters.TA_ORDENES ta = new Data.DataSet1TableAdapters.TA_ORDENES())
            {
                Data.DataSet1.DT_ORDENESDataTable dt = new Data.DataSet1.DT_ORDENESDataTable();
                dt = ta.GetOrdenesByIdPedido(idPedido);


                ObservableCollection<Ordenes> listOrdenes = new ObservableCollection<Ordenes>();


                foreach (DT_ORDENESRow row in dt.Rows)
                {
                    Ordenes objOrden = new Ordenes(row.ID_PEDIDO, row.ID_ORDEN, row.ID_PRODUCTO, row.NOMBRE_PRODUCTO, row.CANTIDAD, row.CON_TODO, row.CON_TODO_MENOS, row.COMENTARIOS);

                    listOrdenes.Add(objOrden);
                }
                return listOrdenes;

            }
           
        }


        public ICommand RefrescarPedidosCommand
        {
            get
            {
                return _refrescarPedidosCommand ?? (_refrescarPedidosCommand = new DevExpress.Mvvm.DelegateCommand(() =>
                {       
                    InitializeData();
                }));
            }
        }



        public ICommand EditarPedidoCommand
        {
            get
            {
                return _editarPedidoCommand ?? (_editarPedidoCommand = new DevExpress.Mvvm.DelegateCommand<Pedidos>((row) =>
                {
                    OrdenVM objOrden = new OrdenVM();
                    objOrden.SourceOrdenes = row.Ordenes;
                    objOrden.ID_PEDIDO = row.ID_PEDIDO;
                    objOrden.ESTATUS = row.ESTATUS;
                    objOrden.NOMBRE_CLIENTE = row.NOMBRE_CLIENTE;
                    objOrden.TELEFONO_CLIENTE = row.TELEFONO_CLIENTE;
                    objOrden.COMENTARIO_PEDIDO = row.COMENTARIOS;
                    objOrden.PARA_LLEVAR = row.PARA_LLEVAR;
                    objOrden.TOTAL_PEDIDO = row.TOTAL;
                    

                    //EditFormVM editformvm = new EditFormVM(row);
                    /*   UICommand aceptarCommand = new UICommand()
                       {
                           Caption = "Aceptar",
                           IsCancel = false,
                           IsDefault = true,
                           Command = new DevExpress.Mvvm.DelegateCommand(() =>
                           {

                           })
                       };

                       UICommand cancelCommand = new UICommand()
                       {
                           Caption = "Cancelar",
                           IsCancel = true,
                           IsDefault = false
                       };*/
                    //EditDlg.ShowDialog(/*new List<UICommand>() {aceptarCommand, cancelCommand }*/null, "Actualizar Registro", editformvm);
                    OrdenDlg.ShowDialog(/*new List<UICommand>() {aceptarCommand, cancelCommand }*/null, "", objOrden);

                    InitializeData();
                }, (row) => row != null && row.ESTATUS != "TERMINADO" && row.ESTATUS != "CANCELADO"));
            }



        }



        public ICommand EnProcesoCommand
        {
            get
            {
                return _enProcesoCommand ?? (_enProcesoCommand = new DevExpress.Mvvm.DelegateCommand<Pedidos>((row) => 
                {
                    using (Data.DataSet1TableAdapters.QueriesTableAdapter ta = new Data.DataSet1TableAdapters.QueriesTableAdapter())
                    {
                        try
                        {
                            ta.actualizarAEnElaboracion(row.ID_PEDIDO);
                            Alertas.ShowMessage($"El Pedido: {row.ID_PEDIDO} cambio a estatus 'EN ELABORACION' ", "AVISO", MessageButton.OK, MessageIcon.Information);
                            InitializeData();
                        }
                        catch (Exception ex)
                        {
                            Alertas.ShowMessage(ex.Message, "AVISO", MessageButton.OK, MessageIcon.Information);
                        }

                    }

                }, (row) => row != null && row.ESTATUS == "CREADO"));
            }
        }


        public ICommand TerminarPedidoCommand
        {
            get
            {
                return _terminarPedidoCommand ?? (_terminarPedidoCommand = new DevExpress.Mvvm.DelegateCommand<Pedidos>((row) =>
                {
                    using (Data.DataSet1TableAdapters.QueriesTableAdapter ta = new Data.DataSet1TableAdapters.QueriesTableAdapter())
                    {
                        try
                        {
                            ta.actualizarATerminado(row.ID_PEDIDO);
                            Alertas.ShowMessage($"El Pedido: {row.ID_PEDIDO} cambio a estatus 'TERMINADO' ", "AVISO", MessageButton.OK, MessageIcon.Information);
                            InitializeData();
                        }
                        catch (Exception ex)
                        {
                            Alertas.ShowMessage(ex.Message, "AVISO", MessageButton.OK, MessageIcon.Information);
                        }

                    }

                }, (row) => row != null && row.ESTATUS == "EN ELABORACION"));
            }
        }


        public ICommand CancelarPedidoCommand
        {
            get
            {
                return _cancelarPedidoCommand ?? (_cancelarPedidoCommand = new DevExpress.Mvvm.DelegateCommand<Pedidos>((row) =>
                {
                    using (Data.DataSet1TableAdapters.QueriesTableAdapter ta = new Data.DataSet1TableAdapters.QueriesTableAdapter())
                    {
                        try
                        {
                            ta.actualizarACancelado(row.ID_PEDIDO);
                            Alertas.ShowMessage($"El Pedido: {row.ID_PEDIDO} cambio a estatus 'CANCELADO' ", "AVISO", MessageButton.OK, MessageIcon.Information);
                            InitializeData();
                        }
                        catch (Exception ex)
                        {
                            Alertas.ShowMessage(ex.Message, "AVISO", MessageButton.OK, MessageIcon.Information);
                        }

                    }

                }, (row) => row != null && row.ESTATUS != "EN ELABORACION" && row.ESTATUS != "TERMINADO" && row.ESTATUS != "CANCELADO"));
            }
        }

    }
}

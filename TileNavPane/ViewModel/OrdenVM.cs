using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Mvvm;
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraSpreadsheet.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TileNavPane.Model;
using TileNavPane.View;

namespace TileNavPane.ViewModel
{
    public class OrdenVM : DevExpress.Mvvm.ViewModelBase
    {

        private ICommand _actualizarCmd;
        private ICommand _cancelarCmd;
        private ICommand _addOrdenCommand;

    

        public ICurrentDialogService OrdenCurrentDlg { get { return GetService<ICurrentDialogService>("OrdenCurrentDlg"); } }
        public IMessageBoxService Alertas { get { return GetService<IMessageBoxService>("AlertaDlg"); } }


        public OrdenVM() {          
            listIngredientes = new List<string> { "Cebolla", "Cilantro", "Crema", "Aguacate", "Queso" };
            cargarCombo();

            SourceOrdenes = new ObservableCollection<Ordenes>();
            CONTODO = true;
        }

        public void cargarCombo()
        {
            using (Data.DataSet1TableAdapters.TA_PRODUCTOS ta = new Data.DataSet1TableAdapters.TA_PRODUCTOS())
            {

                Data.DataSet1.DT_PRODUCTOSDataTable dt = new Data.DataSet1.DT_PRODUCTOSDataTable();

                dt = ta.GetData();

                DatasourceProductos = dt.ToList();
            }
        }

        /*------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public List<Data.DataSet1.DT_PRODUCTOSRow> DatasourceProductos
        {
            get { return GetProperty(() => DatasourceProductos); }
            set { SetProperty(() => DatasourceProductos, value); }
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
        public string NOMBRE_PRODUCTO
        {
            get { return GetProperty(() => NOMBRE_PRODUCTO); }
            set { SetProperty(() => NOMBRE_PRODUCTO, value); }
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

        public bool CONTODO
        {
            get { return GetProperty(() => CONTODO); }
            set { SetProperty(() => CONTODO, value); }
        }

        public bool CONTODOMENOS
        {
            get { return GetProperty(() => CONTODOMENOS); }
            set { SetProperty(() => CONTODOMENOS, value); }
        }

        public string CON_TODO_MENOS
        {
            get { return GetProperty(() => CON_TODO_MENOS);}
            set { SetProperty(() => CON_TODO_MENOS, value);}    
        }

        public string COMENTARIOS
        {
            get { return GetProperty(() => COMENTARIOS); }
            set { SetProperty(() => COMENTARIOS, value); }
        }

        public bool habilitar
        {
            get { return GetProperty(() => habilitar); }
            set { SetProperty(() => habilitar, value); }
        }

        public List<object> INGREDIENTES
        {
            get { return GetProperty(() => INGREDIENTES); }
            set { SetProperty(() => INGREDIENTES, value); }
        }

        public ObservableCollection<Ordenes> SourceOrdenes
        {
            get { return GetProperty(() => SourceOrdenes); }
            set { SetProperty(() => SourceOrdenes, value); }
        }


        public string NOMBRE_CLIENTE
        {
            get { return GetProperty(() => NOMBRE_CLIENTE); }
            set { SetProperty(() => NOMBRE_CLIENTE, value); }
        }

        public string TELEFONO_CLIENTE
        {
            get { return GetProperty(() => TELEFONO_CLIENTE); }
            set { SetProperty(() => TELEFONO_CLIENTE, value); }
        }

        public string COMENTARIO_PEDIDO
        {
            get { return GetProperty(() => COMENTARIO_PEDIDO); }
            set { SetProperty(() => COMENTARIO_PEDIDO, value); }
        }

        public bool PARA_LLEVAR
        {
            get { return GetProperty(() => PARA_LLEVAR); }
            set { SetProperty(() => PARA_LLEVAR, value); }
        }

        public int TOTAL_PEDIDO
        {
            get { return GetProperty(() => TOTAL_PEDIDO); }
            set { SetProperty(() => TOTAL_PEDIDO, value); }
        }

        /*------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/


        public ICommand AddOrdenCommand
        {
            get
            {
                return _addOrdenCommand ?? (_addOrdenCommand = new DelegateCommand(() =>
                {
                    //if (!SourceOrdenes.Any(x => x.Direccion == TempCorreo.Trim() && x.Tipo == SelectedTipoEnvio.ToString().Trim()))
                    //{
                    //    SourceCorreos.Add(new Correo(TempCorreo.Trim(), SelectedTipoEnvio.ToString().Trim()));
                    //}
                    //TempCorreo = string.Empty;
                    //SelectedTipoEnvio = "To";
                    //SourceOrdenes.Add(new Ordenes(NOMBRE_PRODUCTO, CANTIDAD, INGREDIENTES, COMENTARIOS));


                    string strIngredientes = string.Empty;
                    if (INGREDIENTES != null)
                    {
                       string delim = ",";
                       strIngredientes = String.Join(delim, INGREDIENTES);
                    }



                    //SourceOrdenes.Add(new Ordenes() { NOMBRE_PRODUCTO = NOMBRE_PRODUCTO, CANTIDAD = CANTIDAD, CON_TODO = CONTODO, CON_TODO_MENOS = strIngredientes, COMENTARIOS = COMENTARIOS});
                    SourceOrdenes.Add(new Ordenes(NOMBRE_PRODUCTO, CANTIDAD, CONTODO, strIngredientes, COMENTARIOS));

                    TOTAL_PEDIDO = SourceOrdenes.Sum(o => o.TOTAL_ORDEN);

                 
                    COMENTARIOS = string.Empty;
                    CANTIDAD = 0;
                    NOMBRE_PRODUCTO = string.Empty;
                    INGREDIENTES = null;
                    CONTODO = true;
                    //habilitar = false;
                    seleccionRadio("Con todo");

                },()  => { return (NOMBRE_PRODUCTO != null && CANTIDAD != 0 && habilitar == false) || (NOMBRE_PRODUCTO != null && CANTIDAD != 0 && habilitar == true && INGREDIENTES != null);} ));
            }
        }

      



        public ICommand ActualizarCmd
        {
            get
            {
                return _actualizarCmd ?? (_actualizarCmd = new DevExpress.Mvvm.DelegateCommand(() =>
                {

                    using (Data.DataSet1TableAdapters.QueriesTableAdapter ta = new Data.DataSet1TableAdapters.QueriesTableAdapter())
                    {
                        try
                        {
                            var idPedido = ta.GuardarPedido(PARA_LLEVAR, NOMBRE_CLIENTE, TELEFONO_CLIENTE, COMENTARIO_PEDIDO, TOTAL_PEDIDO);
                            foreach (var item in SourceOrdenes)
                            {
                                ta.GuardarOrdenes(Convert.ToInt32(idPedido), item.NOMBRE_PRODUCTO, item.CANTIDAD, item.CON_TODO, item.CON_TODO_MENOS, item.COMENTARIOS);
                            }
                            Alertas.ShowMessage("Pedido realizado con exito", "AVISO", MessageButton.OK, MessageIcon.Information);
                        }
                        catch (Exception ex) {
                            Alertas.ShowMessage(ex.Message,"AVISO", MessageButton.OK, MessageIcon.Information);
                        }

                    }
                   

                }, ()  => { return SourceOrdenes.Count > 0 && !string.IsNullOrEmpty(NOMBRE_CLIENTE) && !string.IsNullOrEmpty(TELEFONO_CLIENTE); } ));
            }
        }


        public ICommand CancelarCmd
        {
            get
            {
                return _cancelarCmd ?? (_cancelarCmd = new DevExpress.Mvvm.DelegateCommand(() =>
                {
                    OrdenCurrentDlg.Close();
                }));
            }
        }



        public ICommand commandRadio
        {
            get
            {
                return new DevExpress.Mvvm.DelegateCommand<string>((parametro) => 
                { 
                    seleccionRadio(parametro); 
                });
            }
        }




        private void seleccionRadio(string parameter)
        {

            switch (parameter)
            {
                case "Con todo":
                        INGREDIENTES = null;
                        habilitar = false;
                        CONTODO = true;
                    break;
                case "Con todo menos":
                        habilitar = true;
                        CONTODOMENOS = true;
                    break;
            }

        }


      

        //public bool IsChecked = true;
        //private bool AddCanExecute(Object user) { return IsChecked ? true : false; }

    }
}

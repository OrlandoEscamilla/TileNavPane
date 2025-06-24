using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TileNavPane.Data.DataSet1;
using TileNavPane.Model;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using System.Windows.Input;
using SpreadsheetLight;
using DevExpress.Utils.CommonDialogs.Internal;
using Microsoft.Win32;
using System.Windows;
using DevExpress.XtraSpreadsheet.Services.Implementation;

namespace TileNavPane.ViewModel
{
    public class CobroVM : DevExpress.Mvvm.ViewModelBase
    {
        ICommand _refrescarPedidosCommand;

        ICommand _cancelarPedidoCommand;

        ICommand _cobrarPedidoCommand;

        ICommand _descargarPedidosCommand;




        public IMessageBoxService Alertas { get { return GetService<IMessageBoxService>("AlertaDlg"); } }
        protected IDialogService VentanaCobroDlg { get { return this.GetService<IDialogService>("VentanaCobroDlg"); } }

        protected IMessageBoxService MessageBoxService { get { return this.GetService<IMessageBoxService>(); } }

        public CobroVM()
        {
            //MetodoPagoSeleccionado = MetodoPago[0]; // opcional: valor seleccionado por defecto
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
                dt = ta.GetDataByEstatusTerminado();


                List<Pedidos> listPedidos = new List<Pedidos>();

                foreach (DT_PEDIDOSRow row in dt.Rows)
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



        //public ICommand EditarPedidoCommand
        //{
        //    get
        //    {
        //        return _editarPedidoCommand ?? (_editarPedidoCommand = new DevExpress.Mvvm.DelegateCommand<Pedidos>((row) =>
        //        {
        //            OrdenVM objOrden = new OrdenVM();
        //            objOrden.SourceOrdenes = row.Ordenes;
        //            objOrden.ID_PEDIDO = row.ID_PEDIDO;
        //            objOrden.ESTATUS = row.ESTATUS;
        //            objOrden.NOMBRE_CLIENTE = row.NOMBRE_CLIENTE;
        //            objOrden.TELEFONO_CLIENTE = row.TELEFONO_CLIENTE;
        //            objOrden.COMENTARIO_PEDIDO = row.COMENTARIOS;
        //            objOrden.PARA_LLEVAR = row.PARA_LLEVAR;
        //            objOrden.TOTAL_PEDIDO = row.TOTAL;


        //            //EditFormVM editformvm = new EditFormVM(row);
        //            /*   UICommand aceptarCommand = new UICommand()
        //               {
        //                   Caption = "Aceptar",
        //                   IsCancel = false,
        //                   IsDefault = true,
        //                   Command = new DevExpress.Mvvm.DelegateCommand(() =>
        //                   {

        //                   })
        //               };

        //               UICommand cancelCommand = new UICommand()
        //               {
        //                   Caption = "Cancelar",
        //                   IsCancel = true,
        //                   IsDefault = false
        //               };*/
        //            //EditDlg.ShowDialog(/*new List<UICommand>() {aceptarCommand, cancelCommand }*/null, "Actualizar Registro", editformvm);
        //            OrdenDlg.ShowDialog(/*new List<UICommand>() {aceptarCommand, cancelCommand }*/null, "", objOrden);

        //            InitializeData();
        //        }, (row) => row != null && row.ESTATUS != "TERMINADO" && row.ESTATUS != "CANCELADO"));
        //    }



        //}






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

                }, (row) => row != null ));
            }
        }

        public ICommand CobrarPedidoCommand
        {
            get
            {
                return _cobrarPedidoCommand ?? (_cobrarPedidoCommand = new DevExpress.Mvvm.DelegateCommand<Pedidos>((row) =>
                {
                    VentanaCobroVM objCobro = new VentanaCobroVM();
                    objCobro.SourceOrdenes = row.Ordenes;
                    objCobro.ID_PEDIDO = row.ID_PEDIDO;
                    objCobro.ESTATUS = row.ESTATUS;
                    objCobro.NOMBRE_CLIENTE = row.NOMBRE_CLIENTE;
                    objCobro.TELEFONO_CLIENTE = row.TELEFONO_CLIENTE;
                    objCobro.COMENTARIO_PEDIDO = row.COMENTARIOS;
                    objCobro.PARA_LLEVAR = row.PARA_LLEVAR;
                    objCobro.TOTAL_PEDIDO = row.TOTAL;


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
                    VentanaCobroDlg.ShowDialog(/*new List<UICommand>() {aceptarCommand, cancelCommand }*/null, "Cobrar Pedido", objCobro);

                    InitializeData();

                }, (row) => row != null));
            }
        }


        public ICommand DescargarPedidosCommand
        {
            get
            {
                return _descargarPedidosCommand ?? (_descargarPedidosCommand = new DelegateCommand(() =>
                {
                    // Verifica que haya datos para exportar
                    if (DataSource == null || !DataSource.Any())
                    {
                        MessageBoxService.Show("No hay pedidos para exportar.", "Información", MessageButton.OK, MessageIcon.Information, MessageResult.OK);
                        return; // Sale del comando si no hay datos
                    }

                    // USO DEL SAVEFILEDIALOG ESTÁNDAR DE .NET (Microsoft.Win32)
                    // Aunque DevExpress ofrece ISaveFileDialogService, si ya tienes un SaveFileDialog funcionando,
                    // puedes mantenerlo, pero la responsabilidad de la UI sigue siendo de la vista o de un servicio.
                    // Para este ejemplo, lo mantenemos aquí por simplicidad al corregir tu código.
                    Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                    saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"; // Filtra para mostrar solo archivos .xlsx
                    saveFileDialog.Title = "Guardar Reporte de Pedidos"; // Título de la ventana
                    saveFileDialog.FileName = "ReporteDePedidos.xlsx"; // Nombre de archivo predeterminado
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Directorio inicial

                    // ¡Importante! En WPF, ShowDialog() devuelve un bool?
                    if (saveFileDialog.ShowDialog() == true) // Compara con 'true' para WPF
                    {
                        try
                        {
                            // Asegúrate de que tu método GeneratePedidosExcel pueda manejar List<Pedidos>
                            // Si tu ExcelGenerator espera ObservableCollection<Ordenes>, deberías pasársela así:
                            // ExcelGenerator.GeneratePedidosExcel(DataSource.ToList(), saveFileDialog.FileName); // Si DataSource es ObservableCollection
                            // O si GeneratePedidosExcel ya espera List<Pedidos>, está bien como lo tienes:
                            GenerarPedidosExcel(DataSource, saveFileDialog.FileName);

                            MessageBoxService.Show("El archivo de Excel se ha guardado correctamente.", "Éxito", MessageButton.OK, MessageIcon.Information, MessageResult.OK);
                        }
                        catch (Exception ex)
                        {
                            // Usa el servicio de MessageBox de DevExpress
                            MessageBoxService.Show($"Ocurrió un error al guardar el archivo: {ex.Message}", "Error", MessageButton.OK, MessageIcon.Error, MessageResult.OK);
                        }
                    }
                    else
                    {
                        // El usuario canceló la operación
                        MessageBoxService.Show("La operación de guardar archivo fue cancelada.", "Información", MessageButton.OK, MessageIcon.Information, MessageResult.OK);
                    }

                }));
            }
        }

        public static void GenerarPedidosExcel(List<Pedidos> fuente, string filePath)
        {
            SLDocument sl = new SLDocument();
            int currentRow = 1;

            // **Encabezados de la tabla de Pedidos**
            sl.SetCellValue(currentRow, 1, "ID Pedido");
            sl.SetCellValue(currentRow, 2, "Fecha/Hora");
            sl.SetCellValue(currentRow, 3, "Estatus");
            sl.SetCellValue(currentRow, 4, "¿Para Llevar?");
            sl.SetCellValue(currentRow, 5, "Cliente");
            sl.SetCellValue(currentRow, 6, "Teléfono");
            sl.SetCellValue(currentRow, 7, "Comentarios Pedido");
            sl.SetCellValue(currentRow, 8, "Total Pedido");
            sl.SetCellValue(currentRow, 9, "Usuario Captura");
            //sl.SetRowStyle(currentRow, SLStyle.CreateStyle(sl.GetRowStyle(currentRow)).SetFontBold(true)); // Negritas
            currentRow++;



            foreach (var pedido in fuente)
            {
                int startRowForGroupingOrders = currentRow; // Marca el inicio de las filas a agrupar (las órdenes)

                // **Datos del Pedido**
                sl.SetCellValue(currentRow, 1, pedido.ID_PEDIDO);
                sl.SetCellValue(currentRow, 2, pedido.FECHA_HORA);
                sl.SetCellValue(currentRow, 3, pedido.ESTATUS);
                sl.SetCellValue(currentRow, 4, pedido.PARA_LLEVAR ? "Sí" : "No");
                sl.SetCellValue(currentRow, 5, pedido.NOMBRE_CLIENTE);
                sl.SetCellValue(currentRow, 6, pedido.TELEFONO_CLIENTE);
                sl.SetCellValue(currentRow, 7, pedido.COMENTARIOS);
                sl.SetCellValue(currentRow, 8, pedido.TOTAL);
                sl.SetCellValue(currentRow, 9, pedido.USUARIO_CAPTURA);
                //sl.SetRowStyle(currentRow, SLStyle.CreateStyle(sl.GetRowStyle(currentRow)).SetFillColor(System.Drawing.Color.LightBlue)); // Un poco de color para los pedidos
                // sl.SetRowStyle(currentRow, SLS)
                currentRow++;


                // **Encabezados de la tabla de Órdenes (solo si hay órdenes)**
                if (pedido.Ordenes != null && pedido.Ordenes.Any()) // Usa .Any() de System.Linq
                {
                    sl.SetCellValue(currentRow, 2, "ID Orden"); // Empezar en la columna 2 para indentar
                    sl.SetCellValue(currentRow, 3, "ID Producto");
                    sl.SetCellValue(currentRow, 4, "Producto");
                    sl.SetCellValue(currentRow, 5, "Cantidad");
                    sl.SetCellValue(currentRow, 6, "¿Con Todo?");
                    sl.SetCellValue(currentRow, 7, "Con Todo Menos");
                    sl.SetCellValue(currentRow, 8, "Comentarios Orden");
                    sl.SetCellValue(currentRow, 9, "Total Orden");
                    //sl.SetRowStyle(currentRow, SLStyle.CreateStyle(sl.GetRowStyle(currentRow)).SetFontBold(true).SetFontItalic(true)); // Negritas e Itálicas para órdenes
                    currentRow++;

                    foreach (var orden in pedido.Ordenes)
                    {
                        sl.SetCellValue(currentRow, 2, orden.ID_ORDEN);
                        sl.SetCellValue(currentRow, 3, orden.ID_PRODUCTO);
                        sl.SetCellValue(currentRow, 4, orden.NOMBRE_PRODUCTO);
                        sl.SetCellValue(currentRow, 5, orden.CANTIDAD);
                        sl.SetCellValue(currentRow, 6, orden.CON_TODO ? "Sí" : "No");
                        sl.SetCellValue(currentRow, 7, orden.CON_TODO_MENOS);
                        sl.SetCellValue(currentRow, 8, orden.COMENTARIOS);
                        sl.SetCellValue(currentRow, 9, orden.TOTAL_ORDEN);
                        currentRow++;
                    }

                    // **Agrupar las filas de las órdenes**
                    // El rango es desde la fila que contiene el primer encabezado de orden
                    // hasta la fila que contiene la última orden.
                    int endRowForGroupingOrders = currentRow - 1;
                    sl.GroupRows(startRowForGroupingOrders + 1, endRowForGroupingOrders); // +1 para excluir el encabezado de las órdenes del grupo colapsable
                    sl.CollapseRows(startRowForGroupingOrders + 2); // Colapsar el grupo, la caja de colapsado aparece *después* de la primera fila agrupada.
                                                                    // Ajusta este número si quieres que se muestre inicialmente diferente.
                }

                currentRow++; // Un espacio en blanco entre pedidos para mayor legibilidad

            }

            // Autoajustar el ancho de las columnas para que el contenido sea visible
            for (int col = 1; col <= 9; col++)
            {
                sl.AutoFitColumn(col);
            }

            sl.SaveAs(filePath);
            Console.WriteLine("Archivo 'PedidosConOrdenesAgrupadas.xlsx' creado exitosamente.");




        }

    }
}

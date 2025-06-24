using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TileNavPane.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data;

namespace TileNavPane.ViewModel
{
    public class VentanaCobroVM : DevExpress.Mvvm.ViewModelBase
    {
        private ICommand _actualizarCmd;
        private ICommand _cancelarCmd;
        private ICommand _addOrdenCommand;
        private ICommand _borrarOrdenCommand;
        private ICommand _cobrarPedidoCmd;



        public ICurrentDialogService OrdenCurrentDlg { get { return GetService<ICurrentDialogService>("OrdenCurrentDlg"); } }
        public IMessageBoxService Alertas { get { return GetService<IMessageBoxService>("AlertaDlg"); } }


        public VentanaCobroVM()
        {
            metodoPago = new List<string> { "Efectivo", "Tarjeta", "Transferencia" };

            SourceOrdenes = new ObservableCollection<Ordenes>();
           
        }

   

        /*------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/


        public List<string> metodoPago
        {
            get { return GetProperty(() => metodoPago); }
            set { SetProperty(() => metodoPago, value); }
        }

        
        public string MetodoPagoSeleccionado
        {
            get { return GetProperty(() => MetodoPagoSeleccionado); }
            set { SetProperty(() => MetodoPagoSeleccionado, value); }
        }


        public int ID_PEDIDO
        {
            get { return GetProperty(() => ID_PEDIDO); }
            set { SetProperty(() => ID_PEDIDO, value); }
        }

        public string ESTATUS
        {
            get { return GetProperty(() => ESTATUS); }
            set { SetProperty(() => ESTATUS, value); }
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

        //public int TOTAL_PEDIDO
        //{
        //    get { return GetProperty(() => TOTAL_PEDIDO); }
        //    set { SetProperty(() => TOTAL_PEDIDO, value); }
        //}

        //public int PROPINA
        //{
        //    get { return GetProperty(() => PROPINA); }
        //    set { SetProperty(() => PROPINA, value); }
        //}
        //public int TOTAL_BRUTO
        //{
        //    get { return GetProperty(() => TOTAL_BRUTO); }
        //    set { SetProperty(() => TOTAL_PEDIDO + PROPINA, value); }
        //}

        public int TOTAL_PEDIDO
        {
            get { return GetProperty(() => TOTAL_PEDIDO); }
            set
            {
                SetProperty(() => TOTAL_PEDIDO, value);
                RaisePropertyChanged(() => TOTAL_BRUTO); // Notifica que TOTAL_BRUTO ha cambiado
                RaisePropertyChanged(() => PORCENTAJE_PROPINA);
            }
        }

        public int PROPINA
        {
            get { return GetProperty(() => PROPINA); }
            set
            {
                SetProperty(() => PROPINA, value);
                RaisePropertyChanged(() => TOTAL_BRUTO); // Notifica que TOTAL_BRUTO ha cambiado
                RaisePropertyChanged(() => PORCENTAJE_PROPINA);
            }
        }

        // Propiedad calculada
        public int TOTAL_BRUTO
        {
            get { return TOTAL_PEDIDO + PROPINA; }
        }


        public double PORCENTAJE_PROPINA => TOTAL_PEDIDO != 0 ? ((double)PROPINA / TOTAL_PEDIDO) * 100 : 0;


        /*------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public ICommand CobrarPedidoCmd
        {
            get
            {
                return _cobrarPedidoCmd ?? (_cobrarPedidoCmd = new DevExpress.Mvvm.DelegateCommand(() =>
                {

                    using (Data.DataSet1TableAdapters.QueriesTableAdapter ta = new Data.DataSet1TableAdapters.QueriesTableAdapter())
                    {
                        string result = ta.CobrarPedido(ID_PEDIDO, MetodoPagoSeleccionado, TOTAL_PEDIDO, PROPINA, PROPINA != 0 ? Convert.ToDecimal(PORCENTAJE_PROPINA) : 0, TOTAL_BRUTO, Singleton.Instance.Session.ID_USUARIO);
                        if(result != "")
                        {
                            Alertas.ShowMessage($"Ocurrio un error al intentar cobrar el pedido {result}", "AVISO", MessageButton.OK, MessageIcon.Error);
                        }
                        else
                        {
                            Alertas.ShowMessage($"Pedido Cobrado", "AVISO", MessageButton.OK, MessageIcon.Information);
                            //imprimir pedido
                            imprimirPedido();

                        }                    
                    }

                   
                }));
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


        public async Task imprimirPedido()
        {
            using (Data.DataSet1TableAdapters.TA_ORDENES ta = new Data.DataSet1TableAdapters.TA_ORDENES())
            {
                Data.DataSet1.DT_ORDENESDataTable dt = new Data.DataSet1.DT_ORDENESDataTable();
                ta.FillDataForTicket(dt, ID_PEDIDO);
            


                //https://parzibyte.me/http-esc-pos-desktop-docs/es/guia/instalar-compartir-impresora.html
                var nombreImpresora = "Termica";
                var operaciones = new List<OperacionHttpEscPos>();
                // https://parzibyte.me/http-esc-pos-desktop-docs/es/esc-pos/iniciar.html
                operaciones.Add(new OperacionHttpEscPos("Iniciar", new List<object> { }));
                operaciones.Add(new OperacionHttpEscPos("EscribirTexto", new List<object> { "Hola\nMundo" }));
                operaciones.Add(new OperacionHttpEscPos("Feed", new List<object> { 2 }));
                // https://parzibyte.me/http-esc-pos-desktop-docs/es/esc-pos/imagen-de-internet.html
                //operaciones.Add(new OperacionHttpEscPos("DescargarImagenDeInternetEImprimir", new List<object> { "https://github.com/parzibyte.png", 380, 0, true }));

                double sumaTotal = 0;
                foreach(DataRow row in dt.Rows)
                {
                    operaciones.Add(new OperacionHttpEscPos("EscribirTexto", new List<object> { row["NOMBRE_PRODUCTO"] }));
                    operaciones.Add(new OperacionHttpEscPos("EscribirTexto", new List<object> { $" ${row["TOTAL"]}" }));
                    operaciones.Add(new OperacionHttpEscPos("Feed", new List<object> { 2 }));
                    sumaTotal = sumaTotal + (double)row["TOTAL"];

                }
                operaciones.Add(new OperacionHttpEscPos("EscribirTexto", new List<object> { "--------------------" }));
                operaciones.Add(new OperacionHttpEscPos("Feed", new List<object> { 2 }));
                operaciones.Add(new OperacionHttpEscPos("EscribirTexto", new List<object> { $"TOTAL: ${sumaTotal}" }));
                operaciones.Add(new OperacionHttpEscPos("Feed", new List<object> { 2 }));



                var serial = "";
                ImpresionConNombrePluginV3 impresion = new ImpresionConNombrePluginV3(operaciones, nombreImpresora, serial);
                var serializado = JsonSerializer.Serialize(impresion);
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        StringContent content = new StringContent(serializado, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync("http://localhost:8000/imprimir", content);
                        string respuestaComoJson = await response.Content.ReadAsStringAsync();
                        RespuestaHttpEscPos respuestaHttpEscPos = JsonSerializer.Deserialize<RespuestaHttpEscPos>(respuestaComoJson);

                        if (respuestaHttpEscPos.ok)
                        {
                            Console.WriteLine("Impreso correctamente");
                        }
                        else
                        {
                            Console.WriteLine("Petición realizada, pero error en el plugin: " + respuestaHttpEscPos.message);
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Error haciendo petición al plugin. Guía: https://parzibyte.me/http-esc-pos-desktop-docs/es/ el error es: " + e.ToString());
                }
            }
        }


    }
}

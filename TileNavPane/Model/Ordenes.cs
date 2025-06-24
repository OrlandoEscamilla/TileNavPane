using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileNavPane.Model
{
    public class Ordenes 
    {
        public Ordenes() { }

        public Ordenes(string nombre_producto, int cantidad, bool con_todo, string con_todo_menos, string comentarios) {
            this.NOMBRE_PRODUCTO = nombre_producto;
            this.CANTIDAD = cantidad;
            this.CON_TODO = con_todo;
            this.CON_TODO_MENOS = con_todo_menos;
            this.COMENTARIOS = comentarios;
            this.TOTAL_ORDEN = calcularTotalOrden(nombre_producto, cantidad);
        }

        public Ordenes(int idPedido, int idOrden, int idProducto, string nombre_producto, int cantidad, bool con_todo, string con_todo_menos, string comentarios) {
            this.ID_PEDIDO = idPedido;
            this.ID_ORDEN = idOrden;
            this.ID_PRODUCTO = idProducto;
            this.NOMBRE_PRODUCTO = nombre_producto;
            this.CANTIDAD = cantidad;
            this.CON_TODO = con_todo;
            this.CON_TODO_MENOS = con_todo_menos;
            this.COMENTARIOS = comentarios;
            this.TOTAL_ORDEN = calcularTotalOrden(nombre_producto, cantidad);
        }


        public int ID_ORDEN { get; set; }

        public int ID_PEDIDO { get; set; }

        public int ID_PRODUCTO { get; set; }

        public string NOMBRE_PRODUCTO { get; set; }

        public int CANTIDAD { get; set; }
        
        public bool CON_TODO { get; set; }

        public string CON_TODO_MENOS { get; set; }

        public string COMENTARIOS { get; set; }

        public int TOTAL_ORDEN { get; set; }

        private int calcularTotalOrden(string nombre_producto, int cantidad)
        {
            using (Data.DataSet1TableAdapters.QueriesTableAdapter ta = new Data.DataSet1TableAdapters.QueriesTableAdapter())
            {
                int precioProducto = ta.getPrecioProducto(nombre_producto) ?? 0;
                return precioProducto * cantidad;
            }          
        }

    }
}

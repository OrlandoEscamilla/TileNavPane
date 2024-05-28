using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileNavPane.Common
{
    public class OM_SESION
    {

        public int? ID_USUARIO { get; set; }

        public string NOMBRE { get; set; }

        public string USERNAME { get; set; }

        public bool ES_ADMIN { get; set; }

        public string ID_APLICACION { get; set; }

        public string DESCR_APLICACION { get; set; }

        public bool APLICACION_ACTIVA { get; set; }

        public string CONTRASENIA { get; set; }

        public string VALIDACION_AUTENTIFICACION { get; set; }

        public string NOMBRE_DISPOSITIVO_MOB { get; set; }

        public OM_SESION()
        {
            ID_USUARIO = null;
            NOMBRE = "";
            USERNAME = "";
            ES_ADMIN = false;
            ID_APLICACION = "";
            DESCR_APLICACION = "";
            APLICACION_ACTIVA = false;
            CONTRASENIA = "";
            VALIDACION_AUTENTIFICACION = "";
        }

        public OM_SESION(int sID_USUARIO, string sNOM_USUARIO, string bUSUARIO_ACTIVO, bool bES_ADMIN, string sID_APLICACION, string sDESCR_APLICACION, bool bAPLICACION_ACTIVA, string sCONTRASENIA)
        {
            ID_USUARIO = sID_USUARIO;
            NOMBRE = sNOM_USUARIO.Trim();
            USERNAME = bUSUARIO_ACTIVO;
            ES_ADMIN = bES_ADMIN;          
            ID_APLICACION = sID_APLICACION.Trim();
            DESCR_APLICACION = sDESCR_APLICACION.Trim();
            APLICACION_ACTIVA = bAPLICACION_ACTIVA;
            CONTRASENIA = sCONTRASENIA.Trim();
        }

    }
}

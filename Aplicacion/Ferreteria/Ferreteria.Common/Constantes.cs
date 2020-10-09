using System;

namespace Ferreteria.Common
{
    public class Constantes
    {
        #region Mensajes

        public const string Mensaje_Insercion_Correcta = "Registro insertado correctamente";
        public const string Mensaje_Actualizacion_Correcta = "Registro actualizado correctamente";
        public const string Mensaje_Eliminacion_Correcta = "Registro eliminado correctamente";

        #endregion

        #region Errores

        public const string Mensaje_Error_No_Controlado = "Error no controlado: ";

        #endregion

        #region Estados

        public const string Codigo_Estado_Activo = "ACT";
        public const string Codigo_Estado_Pendiente = "PEN";
        public const string Codigo_Estado_Pagado = "PAG";

        #endregion

        #region Roles

        public const string Rol_Credito = "credito";

        #endregion

        #region Parametros Generales

        public const string Parametro_Descripcion_Saldo = "SALABO";

        #endregion
    }
}

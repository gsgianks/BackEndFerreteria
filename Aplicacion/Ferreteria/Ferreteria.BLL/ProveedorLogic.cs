using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
using System.Linq;

namespace Ferreteria.BLL
{
    public class ProveedorLogic : IProveedorLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProveedorLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ResultadoBaseModel Delete(Proveedor modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                if (_unitOfWork.Proveedores.Delete(modelo))
                {
                    result.Descripcion = Constantes.Mensaje_Eliminacion_Correcta;
                }
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Proveedor> GetById(int id)
        {
            RespuestaModel<Proveedor> result = new RespuestaModel<Proveedor>();

            try
            {
                result.Items.Add(_unitOfWork.Proveedores.GetById(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Proveedor> GetList()
        {
            RespuestaModel<Proveedor> result = new RespuestaModel<Proveedor>();

            try
            {
                result.Items = _unitOfWork.Proveedores.GetList().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Proveedor> Insert(Proveedor modelo)
        {
            RespuestaModel<Proveedor> result = new RespuestaModel<Proveedor>();

            try
            {
                //Datos necesarios para la inserción.
                modelo.Fecha_Creacion = DateTime.Now;
                modelo.Usuario_Creacion = "giank";

                //Insertar y recuperar el registro.
                var id = _unitOfWork.Proveedores.Insert(modelo);
                result.Items.Add(_unitOfWork.Proveedores.GetById(id));
                result.Descripcion = Constantes.Mensaje_Insercion_Correcta;
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public ResultadoBaseModel Update(Proveedor modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                modelo.Fecha_Modificacion = DateTime.Now;
                modelo.Usuario_Modificacion = "giank";

                if (_unitOfWork.Proveedores.Update(modelo))
                {
                    result.Descripcion = Constantes.Mensaje_Actualizacion_Correcta;
                }
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

    }
}

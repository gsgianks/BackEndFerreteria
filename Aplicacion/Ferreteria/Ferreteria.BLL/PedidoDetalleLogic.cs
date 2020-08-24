using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
using System.Linq;

namespace Ferreteria.BLL
{
    public class PedidoDetalleLogic : IPedidoDetalleLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public PedidoDetalleLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ResultadoBaseModel Delete(PedidoDetalle modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                if (_unitOfWork.PedidosDetalle.Delete(modelo))
                {
                    result.Descripcion = Mensajes.Mensaje_Eliminacion_Correcta;
                }
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Mensajes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<PedidoDetalle> GetById(int id)
        {
            RespuestaModel<PedidoDetalle> result = new RespuestaModel<PedidoDetalle>();

            try
            {
                result.Items.Add(_unitOfWork.PedidosDetalle.GetById(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Mensajes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<PedidoDetalle> GetList()
        {
            RespuestaModel<PedidoDetalle> result = new RespuestaModel<PedidoDetalle>();

            try
            {
                result.Items = _unitOfWork.PedidosDetalle.GetList().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Mensajes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<PedidoDetalle> Insert(PedidoDetalle modelo)
        {
            RespuestaModel<PedidoDetalle> result = new RespuestaModel<PedidoDetalle>();

            try
            {
                //Datos necesarios para la inserción.
                modelo.Fecha_Creacion = DateTime.Now;
                modelo.Usuario_Creacion = "giank";

                //Insertar y recuperar el registro.
                var id = _unitOfWork.PedidosDetalle.Insert(modelo);
                result.Items.Add(_unitOfWork.PedidosDetalle.GetById(id));
                result.Descripcion = Mensajes.Mensaje_Insercion_Correcta;
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Mensajes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public ResultadoBaseModel Update(PedidoDetalle modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                modelo.Fecha_Modificacion = DateTime.Now;
                modelo.Usuario_Modificacion = "giank";

                if (_unitOfWork.PedidosDetalle.Update(modelo))
                {
                    result.Descripcion = Mensajes.Mensaje_Actualizacion_Correcta;
                }
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Mensajes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }
        
        public RespuestaModel<PedidoDetalleDto> Obtener(int id)
        {
            RespuestaModel<PedidoDetalleDto> result = new RespuestaModel<PedidoDetalleDto>();

            try
            {
                result.Items.Add(_unitOfWork.PedidosDetalle.Obtener(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Mensajes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<PedidoDetalleDto> ObtenerTodos()
        {
            RespuestaModel<PedidoDetalleDto> result = new RespuestaModel<PedidoDetalleDto>();

            try
            {
                result.Items = _unitOfWork.PedidosDetalle.ObtenerTodos().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Mensajes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

    }
}

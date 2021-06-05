using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
using System.Linq;

namespace Ferreteria.BLL
{
    public class PedidoLogic : IPedidoLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public PedidoLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ResultadoBaseModel Delete(Pedido modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                if (_unitOfWork.Pedidos.Delete(modelo))
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

        public RespuestaModel<Pedido> GetById(int id)
        {
            RespuestaModel<Pedido> result = new RespuestaModel<Pedido>();

            try
            {
                result.Items.Add(_unitOfWork.Pedidos.GetById(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Pedido> GetList()
        {
            RespuestaModel<Pedido> result = new RespuestaModel<Pedido>();

            try
            {
                result.Items = _unitOfWork.Pedidos.GetList().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Pedido> Insert(Pedido modelo)
        {
            RespuestaModel<Pedido> result = new RespuestaModel<Pedido>();

            try
            {
                //Datos necesarios para la inserción.
                modelo.Fecha_Creacion = DateTime.Now;
                modelo.Estado = Constantes.Codigo_Estado_Pendiente;

                //Insertar y recuperar el registro.
                var id = _unitOfWork.Pedidos.Insert(modelo);
                result.Items.Add(_unitOfWork.Pedidos.GetById(id));
                result.Descripcion = Constantes.Mensaje_Insercion_Correcta;
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public ResultadoBaseModel Update(Pedido modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {

                if (_unitOfWork.Pedidos.Update(modelo))
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
        
        public RespuestaModel<PedidoDto> Obtener(int id)
        {
            RespuestaModel<PedidoDto> result = new RespuestaModel<PedidoDto>();

            try
            {
                result.Items.Add(_unitOfWork.Pedidos.Obtener(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<PedidoDto> ObtenerTodos()
        {
            RespuestaModel<PedidoDto> result = new RespuestaModel<PedidoDto>();

            try
            {
                result.Items = _unitOfWork.Pedidos.ObtenerTodos().ToList();
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

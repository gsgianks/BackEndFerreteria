using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
using System.Linq;

namespace Ferreteria.BLL
{
    public class PagoCreditoLogic : IPagoCreditoLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public PagoCreditoLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ResultadoBaseModel Delete(PagoCredito modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                if (_unitOfWork.PagosCredito.Delete(modelo))
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

        public RespuestaModel<PagoCredito> GetById(int id)
        {
            RespuestaModel<PagoCredito> result = new RespuestaModel<PagoCredito>();

            try
            {
                result.Items.Add(_unitOfWork.PagosCredito.GetById(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<PagoCredito> GetList()
        {
            RespuestaModel<PagoCredito> result = new RespuestaModel<PagoCredito>();

            try
            {
                result.Items = _unitOfWork.PagosCredito.GetList().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<PagoCredito> Insert(PagoCredito modelo)
        {
            RespuestaModel<PagoCredito> result = new RespuestaModel<PagoCredito>();

            try
            {
                //Datos necesarios para la inserción.
                modelo.Fecha_Creacion = DateTime.Now;

                //Insertar y recuperar el registro.
                var id = _unitOfWork.PagosCredito.Insert(modelo);
                result.Items.Add(_unitOfWork.PagosCredito.GetById(id));
                result.Descripcion = Constantes.Mensaje_Insercion_Correcta;
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public ResultadoBaseModel Update(PagoCredito modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                if (_unitOfWork.PagosCredito.Update(modelo))
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
        
        public RespuestaModel<PagoCreditoDto> Obtener(int id)
        {
            RespuestaModel<PagoCreditoDto> result = new RespuestaModel<PagoCreditoDto>();

            try
            {
                result.Items.Add(_unitOfWork.PagosCredito.Obtener(id));

            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<PagoCreditoDto> ObtenerTodos()
        {
            RespuestaModel<PagoCreditoDto> result = new RespuestaModel<PagoCreditoDto>();

            try
            {
                result.Items = _unitOfWork.PagosCredito.ObtenerTodos().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public ResultadoBaseModel InsertarPagoCredito(PagoCredito modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                result = _unitOfWork.PagosCredito.InsertarPagoCredito(modelo);
                if (result.Codigo == 0) {
                    result.Descripcion = Constantes.Mensaje_Pago_Exitoso;
                }

                if (result.Codigo == 1) {
                    result.DatoExtra = result.Descripcion;
                    result.Descripcion =Constantes.Mensaje_Pago_Exitoso;
                }
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<PagoCreditoDto> ObtenerPorUsuario(int id)
        {
            RespuestaModel<PagoCreditoDto> result = new RespuestaModel<PagoCreditoDto>();

            try
            {
                result.Items = _unitOfWork.PagosCredito.ObtenerPorUsuario(id).ToList();
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

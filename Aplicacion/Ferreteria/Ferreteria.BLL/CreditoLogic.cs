using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
using System.Linq;

namespace Ferreteria.BLL
{
    public class CreditoLogic : ICreditoLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreditoLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ResultadoBaseModel Delete(Credito modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                if (_unitOfWork.Creditos.Delete(modelo))
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

        public RespuestaModel<Credito> GetById(int id)
        {
            RespuestaModel<Credito> result = new RespuestaModel<Credito>();

            try
            {
                result.Items.Add(_unitOfWork.Creditos.GetById(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Credito> GetList()
        {
            RespuestaModel<Credito> result = new RespuestaModel<Credito>();

            try
            {
                result.Items = _unitOfWork.Creditos.GetList().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Credito> Insert(Credito modelo)
        {
            RespuestaModel<Credito> result = new RespuestaModel<Credito>();

            try
            {
                //Datos necesarios para la inserción.
                modelo.Fecha_Creacion = DateTime.Now;
                modelo.Usuario_Creacion = "giank";
                modelo.Estado = Constantes.Codigo_Estado_Pendiente;
                modelo.id = 0;

                //Insertar y recuperar el registro.
                var id = _unitOfWork.Creditos.Insert(modelo);
                result.Items.Add(_unitOfWork.Creditos.GetById(id));
                result.Descripcion = Constantes.Mensaje_Insercion_Correcta;
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public ResultadoBaseModel Update(Credito modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                modelo.Fecha_Modificacion = DateTime.Now;
                modelo.Usuario_Modificacion = "giank";

                if (_unitOfWork.Creditos.Update(modelo))
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
        
        public RespuestaModel<CreditoDto> ObtenerListaCreditos(Credito modelo)
        {
            RespuestaModel<CreditoDto> result = new RespuestaModel<CreditoDto>();

            try
            {
                result.Items = _unitOfWork.Creditos.ObtenerListaCreditos(modelo).ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<CreditoDto> ObtenerTodos()
        {
            RespuestaModel<CreditoDto> result = new RespuestaModel<CreditoDto>();

            try
            {
                result.Items = _unitOfWork.Creditos.ObtenerTodos().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<CreditoDto> ObtenerCreditoUsuario(int id)
        {
            RespuestaModel<CreditoDto> result = new RespuestaModel<CreditoDto>();

            try
            {
                result.Items = _unitOfWork.Creditos.ObtenerCreditoUsuario(id).ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<CreditoDto> ConsultarCreditoUsuario()
        {
            RespuestaModel<CreditoDto> result = new RespuestaModel<CreditoDto>();

            try
            {
                result.Items = _unitOfWork.Creditos.ConsultarCreditoUsuario().ToList();
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

using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
using System.Linq;

namespace Ferreteria.BLL
{
    public class UsuarioLogic : IUsuarioLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ResultadoBaseModel Delete(Usuario modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                if (_unitOfWork.Usuarios.Delete(modelo))
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

        public RespuestaModel<Usuario> GetById(int id)
        {
            RespuestaModel<Usuario> result = new RespuestaModel<Usuario>();

            try
            {
                result.Items.Add(_unitOfWork.Usuarios.GetById(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Usuario> GetList()
        {
            RespuestaModel<Usuario> result = new RespuestaModel<Usuario>();

            try
            {
                result.Items = _unitOfWork.Usuarios.GetList().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Usuario> Insert(Usuario modelo)
        {
            RespuestaModel<Usuario> result = new RespuestaModel<Usuario>();

            try
            {
                //Datos necesarios para la inserción.
                modelo.Fecha_Creacion = DateTime.Now;
                modelo.Usuario_Creacion = "giank";

                //Insertar y recuperar el registro.
                var id = _unitOfWork.Usuarios.Insert(modelo);
                result.Items.Add(_unitOfWork.Usuarios.GetById(id));
                result.Descripcion = Constantes.Mensaje_Insercion_Correcta;
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public ResultadoBaseModel Update(Usuario modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                modelo.Fecha_Modificacion = DateTime.Now;
                modelo.Usuario_Modificacion = "giank";

                if (_unitOfWork.Usuarios.Update(modelo))
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

        public Usuario ValidarUsuario(string cedula, string contrasena) => _unitOfWork.Usuarios.ValidarUsuario(cedula, contrasena);

        public RespuestaModel<UsuarioDto> Obtener(int id)
        {
            RespuestaModel<UsuarioDto> result = new RespuestaModel<UsuarioDto>();

            try
            {
                result.Items.Add(_unitOfWork.Usuarios.Obtener(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<UsuarioDto> ObtenerTodos()
        {
            RespuestaModel<UsuarioDto> result = new RespuestaModel<UsuarioDto>();

            try
            {
                result.Items = _unitOfWork.Usuarios.ObtenerTodos().ToList();
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

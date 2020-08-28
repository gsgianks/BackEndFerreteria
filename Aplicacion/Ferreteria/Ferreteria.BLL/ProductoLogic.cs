using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
using System.Linq;

namespace Ferreteria.BLL
{
    public class ProductoLogic : IProductoLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductoLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ResultadoBaseModel Delete(Producto modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                if (_unitOfWork.Productos.Delete(modelo))
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

        public RespuestaModel<Producto> GetById(int id)
        {
            RespuestaModel<Producto> result = new RespuestaModel<Producto>();

            try
            {
                result.Items.Add(_unitOfWork.Productos.GetById(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Producto> GetList()
        {
            RespuestaModel<Producto> result = new RespuestaModel<Producto>();

            try
            {
                result.Items = _unitOfWork.Productos.GetList().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Producto> Insert(Producto modelo)
        {
            RespuestaModel<Producto> result = new RespuestaModel<Producto>();

            try
            {

                modelo.Fecha_Creacion = DateTime.Now;
                modelo.Usuario_Creacion = "giank";
                modelo.Estado = Constantes.Codigo_Estado_Activo;

                //Insertar.
                var id = _unitOfWork.Productos.Insert(modelo);
                result.Items.Add(_unitOfWork.Productos.GetById(id));
                result.Descripcion = Constantes.Mensaje_Insercion_Correcta;
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public ResultadoBaseModel Update(Producto modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                modelo.Fecha_Modificacion = DateTime.Now;
                modelo.Usuario_Modificacion = "Giank";
                if (_unitOfWork.Productos.Update(modelo))
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
        
        public RespuestaModel<ProductoDto> Obtener(int id)
        {
            RespuestaModel<ProductoDto> result = new RespuestaModel<ProductoDto>();

            try
            {
                result.Items.Add(_unitOfWork.Productos.Obtener(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<ProductoDto> ObtenerTodos()
        {
            RespuestaModel<ProductoDto> result = new RespuestaModel<ProductoDto>();

            try
            {
                result.Items = _unitOfWork.Productos.ObtenerTodos().ToList();
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

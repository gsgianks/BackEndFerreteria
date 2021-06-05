using Ferreteria.Common;
using Ferreteria.Model;
using Ferreteria.Repositories;
using System;
using System.Linq;

namespace Ferreteria.BLL
{
    public class CategoriaLogic : ICategoriaLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriaLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ResultadoBaseModel Delete(Categoria modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                if (_unitOfWork.Categorias.Delete(modelo))
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

        public RespuestaModel<Categoria> GetById(int id)
        {
            RespuestaModel<Categoria> result = new RespuestaModel<Categoria>();

            try
            {
                result.Items.Add(_unitOfWork.Categorias.GetById(id));
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Categoria> GetList()
        {
            RespuestaModel<Categoria> result = new RespuestaModel<Categoria>();

            try
            {
                result.Items = _unitOfWork.Categorias.GetList().ToList();
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public RespuestaModel<Categoria> Insert(Categoria modelo)
        {
            RespuestaModel<Categoria> result = new RespuestaModel<Categoria>();

            try
            {
                //Datos necesarios para la inserción.;
                modelo.Fecha_Creacion = DateTime.Now;

                //Insertar y recuperar el registro.
                var id = _unitOfWork.Categorias.Insert(modelo);
                result.Items.Add(_unitOfWork.Categorias.GetById(id));
                result.Descripcion = Constantes.Mensaje_Insercion_Correcta;
            }
            catch (Exception ex)
            {
                result.Codigo = 99;
                result.Descripcion = Constantes.Mensaje_Error_No_Controlado + ex.Message;
            }

            return result;
        }

        public ResultadoBaseModel Update(Categoria modelo)
        {
            ResultadoBaseModel result = new ResultadoBaseModel();

            try
            {
                modelo.Fecha_Modificacion = DateTime.Now;

                if (_unitOfWork.Categorias.Update(modelo))
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

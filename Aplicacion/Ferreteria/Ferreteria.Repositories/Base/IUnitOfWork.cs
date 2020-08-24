using Ferreteria.Repositories;

namespace Ferreteria.Repositories
{
    public interface IUnitOfWork
    {
        ICreditoRepository Creditos { get; }
        IPagoCreditoRepository PagosCredito { get; }
        IPedidoDetalleRepository PedidosDetalle { get; }
        IPedidoRepository Pedidos { get; }
        IProductoRepository Productos { get; }
        IUsuarioRepository Usuarios { get; }
        ICategoriaRepository Categorias { get; }
        IProveedorRepository Proveedores { get; }

    }
}

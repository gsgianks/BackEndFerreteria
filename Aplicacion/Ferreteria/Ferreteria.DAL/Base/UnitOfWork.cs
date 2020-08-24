using Ferreteria.Repositories;

namespace Ferreteria.DAL
{
    public class FerreteriaUnitOfWork : IUnitOfWork
    {
        public FerreteriaUnitOfWork(string connectionString)
        {
            Usuarios = new UsuarioRepository(connectionString);
            Creditos = new CreditoRepository(connectionString);
            PagosCredito = new PagoCreditoRepository(connectionString);
            PedidosDetalle = new PedidoDetalleRepository(connectionString);
            Pedidos = new PedidoRepository(connectionString);
            Productos = new ProductoRepository(connectionString);
            Categorias = new CategoriaRepository(connectionString);
            Proveedores = new ProveedorRepository(connectionString);
        }
        public IUsuarioRepository Usuarios { get; private set; }
        public ICreditoRepository Creditos { get; private set; }
        public IPagoCreditoRepository PagosCredito { get; private set; }
        public IPedidoDetalleRepository PedidosDetalle { get; private set; }
        public IPedidoRepository Pedidos { get; private set; }
        public IProductoRepository Productos { get; private set; }
        public ICategoriaRepository Categorias { get; private set; }
        public IProveedorRepository Proveedores { get; private set; }
    }
}

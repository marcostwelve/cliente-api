using apiClientes.Model;

namespace apiClientes.Repository
{
    public interface IClienteRepository
    {
        public Task<List<Cliente>> GetClientes();
        public Task<Cliente> GetCliente(int id);
        public Task CriarCliente(Cliente cliente);
        public Task AtualizarCliente(int id, Cliente cliente);
        public Task DeletarCliente(int id);
    }
}

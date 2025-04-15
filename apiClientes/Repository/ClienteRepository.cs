using apiClientes.ApplicationDbContext;
using apiClientes.Helpers.Functions;
using apiClientes.Model;
using Microsoft.EntityFrameworkCore;

namespace apiClientes.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DatabaseDbContext _context;
        public ClienteRepository(DatabaseDbContext context) 
        {
            _context = context;
        }
        public async Task CriarCliente(Cliente cliente)
        {
            try
            {
                if (cliente == null)
                {
                    throw new ArgumentNullException("Nome do cliente obrigatório", nameof(cliente));
                }

                cliente.Documento = ValidarDocumento.MascaraDocumento(cliente.Documento);
                cliente.Telefone = ValidarTelefone.MascaraTelefone(cliente.Telefone);
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

      

        public async Task<Cliente> GetCliente(int id)
        {
            try
            {
                var cliente = await _context.Clientes.Where(x => x.Id == id && x.EstaAtivo == true ).FirstOrDefaultAsync();
                if (cliente == null)
                {
                    throw new ArgumentNullException("Cliente não encontrado", nameof(cliente));
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Cliente>> GetClientes()
        {
            try
            {
                var clientes = await _context.Clientes.Where(x => x.EstaAtivo == true).ToListAsync();
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AtualizarCliente(int id, Cliente cliente)
        {
            try
            {
                var clienteDb = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    throw new ArgumentNullException("Cliente não encontrado", nameof(cliente));
                }

                clienteDb.Nome = cliente.Nome;
                clienteDb.Documento = ValidarDocumento.MascaraDocumento(cliente.Documento);
                clienteDb.Telefone = ValidarTelefone.MascaraTelefone(cliente.Telefone);
                clienteDb.DataCadastro = cliente.DataCadastro;
                clienteDb.TipoCliente = cliente.TipoCliente;
                clienteDb.EstaAtivo = cliente.EstaAtivo;

                _context.Clientes.Update(clienteDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task DeletarCliente(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    throw new ArgumentNullException("Cliente não encontrado", nameof(cliente));
                }

                if (cliente.EstaAtivo)
                {
                    cliente.EstaAtivo = false;
                    _context.Clientes.Update(cliente);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

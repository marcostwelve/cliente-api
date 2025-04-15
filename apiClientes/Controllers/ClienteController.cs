using apiClientes.Model;
using apiClientes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace apiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteService)
        {
            _clienteRepository = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> TodosClientes()
        {
            try
            {
                var clientes = await _clienteRepository.GetClientes();

                if (clientes == null)
                {
                    return NotFound("Não há clientes cadastrados");
                }
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar clientes" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetCliente(id);
                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar cliente" + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente(Cliente cliente)
        {
            try
            {
                if (cliente == null)
                {
                    return BadRequest("Necessário digitar todos os dados para cadastro");
                }

                await _clienteRepository.CriarCliente(cliente);
                return Ok("Cliente criado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao criar cliente" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(int id, Cliente cliente)
        {
            try
            {
                var clienteDb = await _clienteRepository.GetCliente(id);

                if (clienteDb == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                await _clienteRepository.AtualizarCliente(id, cliente);

                return Ok("Cliente atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao atualizar cliente" + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCliente(int id)
        {
            try
            {
                var clienteDb = await _clienteRepository.GetCliente(id);
                if (clienteDb == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                await _clienteRepository.DeletarCliente(id);
                return Ok($"Cliente com o ID {id} deletado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao deletar cliente" + ex.Message);
            }
        }

    }
}

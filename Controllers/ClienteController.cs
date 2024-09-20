using Microsoft.AspNetCore.Mvc;
using RepositorySolucao.Models;
using RepositorySolucao.Repositories;
using RepositorySolucao.Repositories.Interfaces;
using System.Collections.Generic;

namespace RepositorySolucao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = _clienteRepository.Get<Cliente>();
            return Ok(clientes);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            var cliente = _clienteRepository.GetById<Cliente>(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        
        [HttpGet("cpf/{cpf}")]
        public ActionResult<Cliente> GetByCPF(string cpf)
        {
            var cliente = _clienteRepository.GetByCPF(cpf);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        
        [HttpPost]
        public ActionResult<Cliente> CreateCliente([FromBody] Cliente cliente)
        {
            _clienteRepository.Adicionar(cliente);
            if (_clienteRepository.SaveChanges())
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);

            return BadRequest("Erro ao criar o cliente.");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            var existingCliente = _clienteRepository.GetById<Cliente>(id);

            if (existingCliente == null)
                return NotFound();

            existingCliente.Nome = cliente.Nome;
            existingCliente.CPF = cliente.CPF;

            _clienteRepository.Atualizar(existingCliente);

            if (_clienteRepository.SaveChanges())
                return NoContent();

            return BadRequest("Erro ao atualizar o cliente.");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _clienteRepository.GetById<Cliente>(id);
            if (cliente == null)
                return NotFound();

            _clienteRepository.Remover(cliente);
            if (_clienteRepository.SaveChanges())
                return NoContent();

            return BadRequest("Erro ao deletar o cliente.");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RepositorySolucao.Models;
using RepositorySolucao.Repositories.Interfaces;
using System.Collections.Generic;

namespace RepositorySolucao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> GetFornecedores()
        {
            var fornecedores = _fornecedorRepository.Get<Fornecedor>();
            return Ok(fornecedores);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Fornecedor> GetFornecedorById(int id)
        {
            var fornecedor = _fornecedorRepository.GetById<Fornecedor>(id);
            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        
        [HttpPost]
        public ActionResult<Fornecedor> CreateFornecedor([FromBody] Fornecedor fornecedor)
        {
            _fornecedorRepository.Adicionar(fornecedor);
            if (_fornecedorRepository.SaveChanges())
                return CreatedAtAction(nameof(GetFornecedorById), new { id = fornecedor.Id }, fornecedor);

            return BadRequest("Erro ao criar o fornecedor.");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateFornecedor(int id, [FromBody] Fornecedor fornecedor)
        {
            var existingFornecedor = _fornecedorRepository.GetById<Fornecedor>(id);

            if (existingFornecedor == null)
                return NotFound(); 

            existingFornecedor.Nome = fornecedor.Nome;

            _fornecedorRepository.Atualizar(existingFornecedor);

            if (_fornecedorRepository.SaveChanges())
                return NoContent(); 

            return BadRequest("Erro ao atualizar o fornecedor.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFornecedor(int id)
        {
            var fornecedor = _fornecedorRepository.GetById<Fornecedor>(id);
            if (fornecedor == null)
                return NotFound();

            _fornecedorRepository.Remover(fornecedor);
            if (_fornecedorRepository.SaveChanges())
                return NoContent();

            return BadRequest("Erro ao deletar o fornecedor.");
        }
    }
}

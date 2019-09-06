using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interefaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
           
        private IPecaRepository PecaRepository { get; set; }

        public PecasController()
        {
            PecaRepository = new PecaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        { 
            {
                return Ok(PecaRepository.Listar());
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Pecas peca)
        {
            try
            {
                PecaRepository.Cadastrar(peca);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu algum erro :(" + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pecas Peca = PecaRepository.BuscarPorId(id);
            if (Peca == null)
                return NotFound();
            return Ok(Peca);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pecas peca)
        {
            try
            {
                int FornecedorId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "FornecedorId").Value);
                Pecas pecaBuscada = PecaRepository.BuscarPorId(id);
                if (pecaBuscada == null)
                    return NotFound();
                peca.FornecedorId = FornecedorId;
                peca.PecaId = id;
                PecaRepository.Atualizar(peca);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu algum erro :(" + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PecaRepository.Deletar(id);
            return Ok();
        }
    }
}
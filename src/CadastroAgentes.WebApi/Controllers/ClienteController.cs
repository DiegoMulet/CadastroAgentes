using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CadastroAgentes.Business.Interfaces;
using CadastroAgentes.Business.Models;
using CadastroAgentes.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAgentes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, 
                                 IClienteService clienteService,
                                 IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                
                var result = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var result = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteViewModel model)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(model);
                if (await _clienteService.Adicionar(cliente))
                {
                    return Created("", _mapper.Map<ClienteViewModel>(cliente));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }

            return BadRequest();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, ClienteViewModel model)
        {
            try
            {
                var cliente = await _clienteRepository.ObterPorId(id);
                if (cliente == null) return NotFound();

                _mapper.Map(model, cliente);

                if (await _clienteService.Atualizar(cliente))
                {
                    return Created("", _mapper.Map<ClienteViewModel>(cliente));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var cliente = await _clienteRepository.ObterPorId(id);

                if(cliente == null) return NotFound();
                if (await _clienteService.Remover(id))
                {
                    return Ok();
                }
                
                return BadRequest();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }
        }
    }
}

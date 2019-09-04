using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CadastroAgentes.Business.Interfaces;
using CadastroAgentes.Business.Models;
using CadastroAgentes.WebApi.Extensions;
using CadastroAgentes.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAgentes.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class FornecedorController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorRepository fornecedorRepository, 
                                 IFornecedorService fornecedorService,
                                 IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                
                var result = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
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
                var result = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterPorId(id));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[ClaimsAuthorize("Fornecedor", "Adicionar")]
        [HttpPost]
        public async Task<IActionResult> Post(FornecedorViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var fornecedor = _mapper.Map<Fornecedor>(model);
                if (await _fornecedorService.Adicionar(fornecedor))
                {
                    return Created("", _mapper.Map<FornecedorViewModel>(fornecedor));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }

            return BadRequest();
        }

        //[ClaimsAuthorize("Fornecedor", "Alterar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, FornecedorViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var fornecedor = await _fornecedorRepository.ObterPorId(id);
                if (fornecedor == null) return NotFound();

                _mapper.Map(model, fornecedor);

                if (await _fornecedorService.Atualizar(fornecedor))
                {
                    return Created("", _mapper.Map<FornecedorViewModel>(fornecedor));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();

        }

        //[ClaimsAuthorize("Fornecedor", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var fornecedor = await _fornecedorRepository.ObterPorId(id);

                if(fornecedor == null) return NotFound();
                if (await _fornecedorService.Remover(id))
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

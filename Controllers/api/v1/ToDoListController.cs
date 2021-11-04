using api_ToDoList.Models;
using api_ToDoList.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_ToDoList.Controllers.api.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoService _service;
        public ToDoListController(IToDoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna itens cadastrados.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /ToDoList
        ///
        /// </remarks>
        /// <returns>item criados recentemente</returns>
        /// <response code="200">Retorna todos os itens</response>
        /// <response code="400">Não possui itens cadatrados</response>      
        [HttpGet]
        public ActionResult<IEnumerable<ToDoList>> Get()
        {
            try
            {
                var retorno = _service.GetAll().ToList();

                if (retorno == null)
                    return NotFound("Não Foram Encontrados Registros");

                return Ok(retorno);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Retorna um Item com id do parametro.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /ToDoList/2
        ///
        /// </remarks>
        /// <returns>item criados recentemente</returns>
        /// <response code="200">Retorna o item de id igual o parametro</response>
        /// <response code="400">Não possui itens cadatrados com esse id</response>      
        [HttpGet("GetByID/{id}")]
        public ActionResult<ToDoList> GetByID(int id)
        {
            try
            {
                var retorno = _service.GetByID(id);

                if (retorno == null)
                    return NotFound("Não Foram Encontrados Registros");

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            
        }

        /// <summary>
        /// Cria um item novo
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ToDoList
        ///     {
        ///        "Descricao": "Exemplo",
        ///     }
        ///
        /// </remarks>
        /// <returns>item criados recentemente</returns>
        /// <response code="201">Retorna o item criado</response>
        /// <response code="500">"Não Foi Possivel Criar o Objeto"</response> 
        [HttpPut]
        public ActionResult<ToDoList> Create([FromBody] ToDoList list)
        {
            try
            {
                var retorno = _service.Create(list);

                if (retorno == null)
                    return BadRequest("Não Foi Possivel Criar o Objeto");

                return CreatedAtAction(nameof(GetByID), new { id = list.Id}, list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        /// <summary>
        /// Edita um item 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ToDoList/Update
        ///     {
        ///        "Id": 2,
        ///        "Descricao": "Exemplo 2",
        ///     }
        ///
        /// </remarks>
        /// <returns>item criados recentemente</returns>
        /// <response code="201">Retorna o item editado</response>
        /// <response code="500">"Não Foi Possivel Alterar o Objeto"</response> 
        [HttpPost("Update")]
        public ActionResult<ToDoList> Update([FromBody] ToDoList list)
        {
            try
            {

                var retorno = _service.Update(list);

                if (retorno == null)
                    return BadRequest("Não Foi Possivel Alterar o Objeto");

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            
        }

        /// <summary>
        /// Remove um item 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ToDoList/Delete/1
        ///     
        ///
        /// </remarks>
        /// <returns>mensagem de erro ou de exito</returns>
        /// <response code="200">"Objeto Apagado Com Sucesso"</response>
        /// <response code="404">"Não Foi Encontrado o Registro de ID = {id}"</response> 
        /// <response code="400">"Não Foi Possivel Apagar o Objeto"</response> 
        [HttpDelete("Delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var obj = _service.GetByID(id);
                if (obj != null)
                {
                    var retorno = _service.Delete(obj);

                    if (retorno == false)
                        return BadRequest("Não Foi Possivel Apagar o Objeto");

                    return Ok("Objeto Apagado Com Sucesso");
                }
                else
                {
                    return NotFound($"Não Foi Encontrado o Registro de ID = {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
    }
}

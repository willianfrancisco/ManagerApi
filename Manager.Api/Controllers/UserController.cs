using AutoMapper;
using Manager.Api.Utilities;
using Manager.Api.ViewModel;
using Manager.Core.Exceptions;
using Manager.Service.DTO;
using Manager.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Api.Controllers
{
    [Route("/api/v1/users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CreateUserViewModel userViewModel)
        {
            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(userViewModel);

                UserDTO userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso!",
                    Succes = true,
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMenssage());
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]UpdateViewModel updUser)
        {
            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(updUser);

                UserDTO userChanged = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso!",
                    Succes = true,
                    Data = userChanged
                });

            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMenssage());
            }
        }

        [HttpDelete("remove/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _userService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário deletado com sucesso!",
                    Succes = true,
                    Data = null
                });

            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMenssage());
            }
        }

        [HttpGet("get/{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                UserDTO user = await _userService.Get(id);

                if (user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado com o Id informado!",
                        Succes = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Succes = true,
                    Data = user
                });

            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMenssage());
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IList<UserDTO> allUsers = await _userService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados!",
                    Succes = true,
                    Data = allUsers
                });

            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMenssage());
            }
        }

        [HttpGet("search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery]string name)
        {
            try
            {
                IList<UserDTO> allUsers = await _userService.SearchByName(name);

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com o nome informado!",
                    Succes = true,
                    Data = allUsers
                });

            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMenssage());
            }
        }

        [HttpGet("search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery]string email)
        {
            try
            {
                IList<UserDTO> allUsers = await _userService.SearchByEmail(email);

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com o email informado!",
                    Succes = true,
                    Data = allUsers
                });

            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMenssage());
            }
        }

        [HttpGet("get-by-email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                UserDTO Users = await _userService.GetByEmail(email);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrados com o email informado!",
                    Succes = true,
                    Data = Users
                });

            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMenssage());
            }
        }
    }
}

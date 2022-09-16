using Manager.Api.Token;
using Manager.Api.Utilities;
using Manager.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Manager.Api.Controllers
{
    [Route("/api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerate;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerate)
        {
            _configuration = configuration;
            _tokenGenerate = tokenGenerate;
        }

        [HttpPost("login")]
        //[Route("/api/v1/auth/login")]
        public IActionResult GenerateToken([FromBody]LoginViewModel login)
        {
            try
            {
                var tokenLogin = _configuration["Jwt:Login"];
                var tokenPassword = _configuration["Jwt:Password"];

                if (login.Login == tokenLogin && login.Password == tokenPassword)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado com sucesso!",
                        Succes = true,
                        Data = new
                        {
                            Token = _tokenGenerate.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
                }

            }
            catch (Exception)
            {

                return StatusCode(500, Responses.ApplicationErrorMenssage());
            }
        }
    }
}

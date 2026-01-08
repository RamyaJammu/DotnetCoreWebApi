using DotnetCoreWebApi.SErvices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRepository _loginrepository;
        public AuthController(ILoginRepository loginRepository)
        {
            _loginrepository= loginRepository;
        }
        [HttpGet]
        [Route("Account/GenerateToken/{UserName}/{Password}")]
        public IActionResult GenerateToken(string UserName,string Password)
        {
            try
            {
                string token = _loginrepository.GenerateToken(UserName, Password);
                return Ok(token);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DSR_DataAccess.Models;
using DSR_DataAccess.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace DSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminSecurityController : ControllerBase
    {
        private IConfiguration _config;
        private IAdminSecurityService _adminSecurityService;
        public AdminSecurityController(IConfiguration configuration, IAdminSecurityService adminSecurityService)
        {
            _config= configuration;
            _adminSecurityService = adminSecurityService;

        }

        private Dsradmin AuthenticateAdmin(Dsradmin dsradmin)
        {
            Dsradmin _dsradmin = _adminSecurityService.GetDsradmin(dsradmin);
            return _dsradmin;
        }
        private string GenerateToken(Dsradmin dsradmin)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials=new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],_config["Jwt:Audience"],null,
                expires:DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]

        public IActionResult Login(Dsradmin dsradmin)
        {
            IActionResult response = Unauthorized();
            var admin_=AuthenticateAdmin(dsradmin);

            if (admin_ != null)
            {
                var token = GenerateToken(admin_);
                response = Ok(new { token = token });
            }
            return response;
        }

        


    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public ActionResult GetToken()
        {
            var securitykey = "Essa é a nossa frase bem longa";
            var symmetricSecurrityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
            var signCredentials = new SigningCredentials(symmetricSecurrityKey,SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                        issuer: "smesk.in",
                        audience: "readers",
                        expires:DateTime.Now.AddHours(1),
                        signingCredentials: signCredentials
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
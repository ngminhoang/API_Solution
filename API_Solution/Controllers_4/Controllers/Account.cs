using API_6._0_4.DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services_4.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XAct.Library.Settings;
using XSystem.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        private readonly ServicesInterface ser;
        private readonly API_6._0_4.DBcontext.EF_DBcontext db;
        private IConfiguration configuration;
        public Account(ServicesInterface _servicesInterface, API_6._0_4.DBcontext.EF_DBcontext db, IConfiguration configuration)
        {
            try
            {
                ser = _servicesInterface;
                this.db = db;
                this.configuration = configuration;
            }
            catch (Exception ex) { throw ex; }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User model)
        {
            var pass_md5 = GenerateMD5(model.Password);
            var user = db.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == pass_md5);
            if (user != null)
            {
                var key = configuration["Jwt:Key"];
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Country,"Vietnam"),
                    new Claim(ClaimTypes.Role,"admin"),
                };
                var identity = new ClaimsIdentity(claims,"admin");
                var claimPrincipal = new ClaimsPrincipal(identity);
                var adminClaim = claimPrincipal.Claims.ToList();
                //tao token voi thong so khop voi cau hinh
                var token = new JwtSecurityToken(

                        issuer: configuration["Jwt:Issuer"],
                        audience: configuration["Jwt:Audience"],
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signingCredential,
                        claims: adminClaim
                    );
                //sinh chuoi token
                var LocationToken = new JwtSecurityTokenHandler().WriteToken(token);
                return new JsonResult(new { username = model.UserName, token = LocationToken });
            }
            else
            {
                return new JsonResult(new { message = "Sai" });
            }

        }
        private string GenerateMD5(string password)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(password));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

    }
}

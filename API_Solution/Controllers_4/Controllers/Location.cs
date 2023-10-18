using API_6._0_4.DBcontext;
using Microsoft.AspNetCore.Mvc;
using Services_4.Services;
using Services_4.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using XSystem.Security.Cryptography;
using System.Diagnostics.SymbolStore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Services_4.DTOModels;
using XAct.Users;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_6._0_4.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Location : ControllerBase
    {
        private readonly ServicesInterface ser;
        private IConfiguration configuration;
        public Location(ServicesInterface _servicesInterface, IConfiguration configuration)
        {
            try
            {
                ser = _servicesInterface;
                this.configuration = configuration;
            }
            catch (Exception ex) { throw ex; }
        }
        [HttpPost("Create")]
        public IActionResult CreateAccount([FromBody] UserModel model) 
        {
            try
            {

                var data = model;
                data.password = GenerateMD5(model.password);
                return Ok(ser.create(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //[HttpPost("Login")]
        //public IActionResult Login([FromBody] User model)
        //{
        //    var pass_md5 = GenerateMD5(model.Password);
        //    var user = db.Users.FirstOrDefault(x=> x.UserName == model.UserName && x.Password==pass_md5);
        //    if (user != null)
        //    {
        //        var key = configuration["Jwt:Key"];
        //        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //        var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, model.UserName),
        //            new Claim(ClaimTypes.Country,"Vietnam"),
        //            new Claim(ClaimTypes.Role,"admin"),
        //        };

        //        //tao token voi thong so khop voi cau hinh
        //        var token = new JwtSecurityToken(

        //                issuer: configuration["Jwt:Issuer"],
        //                audience: configuration["Jwt:Audience"],
        //                expires: DateTime.Now.AddMinutes(2),
        //                signingCredentials: signingCredential,
        //                claims: claims
        //            );
        //        //sinh chuoi token
        //        var LocationToken = new JwtSecurityTokenHandler().WriteToken(token);
        //        return new JsonResult(new { username = model.UserName, token = LocationToken });
        //    }
        //    else
        //    {
        //        return new JsonResult(new { message= "Sai"});
        //    }
            
        //}

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
        

        //[Authorize]
        [HttpGet("Provinces")]
        public IActionResult Get()
        {
            try
            {
                return Ok(ser.getAllProvinces());
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        // GET
        [HttpGet("Provinces/{id}")]
        public IActionResult selectProvince( int id)
        {
            try
            {
                if(ser.getAllProvinceInfor(id) == null)
                {
                    return BadRequest("CannotBeFound");
                }    
                return Ok(ser.getAllProvinceInfor(id));
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }

        [HttpGet("Districts/{id}")]
        public IActionResult selectDistrict(int id)
        {
            try
            {
                if (ser.getAllDistrictInfor(id) == null)
                {
                    return BadRequest("CannotBeFound");
                }
                return Ok(ser.getAllDistrictInfor(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("Wards/{id}")]
        public IActionResult selectWard(int id)
        {
            try
            {
                if(ser.select("Ward", id)==null)
                {
                    return BadRequest("CannotBeFound");
                }    
                return Ok(ser.select("Ward", id));
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }


        // POST
        [HttpPost("Provinces")]
        [Authorize(Roles = "admin")]
        public IActionResult createProvince([FromBody] ProvinceModel data)
        {
            try {
                var user = HttpContext.User;
                var username = user.Identity.Name;
                //var data = new ProvinceModel() 
                //{ 
                //    provinceID = ser.getMaxID("Province")+1,
                //    provinceName=name,
                //    provinceDescription=des
                //};
                return Ok(ser.create(data));
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }


        [HttpPost("Provinces/{provinceID}/Districts")]
        [Authorize(Roles = "admin")]
        public IActionResult createDistrict(int provinceID, [FromBody] DistrictModel data)
        {
            try
            {

                //var data = new DistrictModel()
                //{ 
                //    districtID = ser.getMaxID("District") + 1,
                //    districtName = name, 
                //    districtDescription = des, 
                //    provinceID = proID,
                //};
                return Ok(ser.create(provinceID,data));
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }

        [HttpPost("Districts/{districtID}/Wards")]
        [Authorize(Roles = "admin")]
        public IActionResult createWard(int districtID, [FromBody] WardModel data)
        {
            try
            {

                //var data = new WardModel() 
                //{
                //    wardID = ser.getMaxID("Ward") + 1,
                //    wardName = name, 
                //    wardDescription = des, 
                //    districtID = disID,
                //};
                return Ok(ser.create(districtID,data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        // PUT
        [HttpPut("Provinces/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult updateProvince([FromBody] ProvinceModel data)
        {
            try {
                return Ok(ser.update(data)); }
            catch (Exception ex) 
            {
                throw ex; 
            }
        }
        [HttpPut("Districts/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult updateDistrict([FromBody] DistrictModel data)
        {
            try
            {
                return Ok(ser.update(data));
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        [HttpPut("Wards/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult updateWard([FromBody] WardModel data)
        {
            try
            {
                return Ok(ser.update(data));
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }


        // DELETE
        [HttpDelete("Provinces/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult deleteProvince(int id)
        {
            try
            {
                return Ok(ser.delete("Province",id));
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }
        [HttpDelete("Districts/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult deleteDistrict(int id)
        {
            try
            {
                return Ok(ser.delete("District", id));
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }
        [HttpDelete("Wards/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult deleteWard(int id)
        {
            try
            {
                return Ok(ser.delete("Ward", id));
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }
    }
}

using API_6._0_4.DBcontext;
using Microsoft.AspNetCore.Mvc;
using Services_4.Services;
using Services_4.Models;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_6._0_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Location : ControllerBase
    {
        private readonly ServicesInterface ser;
        public Location(ServicesInterface _servicesInterface)
        {
            try
            {
                ser = _servicesInterface;
            }
            catch (Exception ex) { throw ex; }
        }


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
        public IActionResult createProvince([FromBody] ProvinceModel data)
        {
            try {

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

using API_6._0_4.DBcontext;
using Services_4.DTOModels;
using Services_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_4.Services
{
    public interface ServicesInterface
    {
        int getMaxID(string t);
        List<Province> getAllProvinces();
        object select(string t, int id);
        string create(UserModel userModel);
        string create(ProvinceModel provinceModel);
        string create(int idProvince, DistrictModel districtModel);
        string create(int idDtrict, WardModel wardModel);
        string update(ProvinceModel provinceModel);
        string update(DistrictModel districtModel);
        string update(WardModel wardModel);
        string delete(string t, int id);
        dynamic getAllDistrictInfor(int districtID);
        dynamic getAllProvinceInfor(int provinceID);
    }
}

using API_6._0_4.Repositories;
using API_6._0_4.DBcontext;
using Services_4.Models;
using Services_4.Mapper;
using AutoMapper;
using Services_4.DTOModels;

namespace Services_4.Services

{
    public class Services : ServicesInterface
    {
        private readonly IMapper mapper;
        private readonly RepositoryInterface<Province> provinceDB;
        private readonly RepositoryInterface<District> districtDB;
        private readonly RepositoryInterface<Ward> wardDB;
        private readonly RepositoryInterface<User> userDB;
        public Services(IMapper _mapper, RepositoryInterface<Ward> reposWar, RepositoryInterface<Province> reposPro, RepositoryInterface<District> reposDis, RepositoryInterface<User> reposUse)
        {
            //provinceDB = new ProvinceRepository(eF_DBcontext);
            //districtDB = new DistrictRepository(eF_DBcontext);
            //wardDB = new WardRepository(eF_DBcontext);

            provinceDB = reposPro;
            districtDB = reposDis;
            wardDB = reposWar;
            userDB = reposUse;
            mapper = _mapper;
        }


        //MAX_ID
        public int getMaxID(string t)
        {
            try
            {
                if (t == "Province") return provinceDB.maxID();
                else if (t == "District") return districtDB.maxID();
                else if (t == "Ward") return wardDB.maxID();
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //READ
        public List<Province> getAllProvinces()
        {
            return provinceDB.getAll().ConvertAll(x => (Province)x);
        }
        public object select(string t, int id)
        {
            try
            {
                if (t == "Province")
                {
                    Province province = (Province)provinceDB.select(id);
                    //var x = new MappingProfile();
                    ProvinceModel provinceModel = mapper.Map<ProvinceModel>(province);
                    //ProvinceModel provinceModel = new ProvinceModel() 
                    //{ 
                    //    provinceID = province.provinceID, 
                    //    provinceName = province.provinceName, 
                    //    provinceDescription = province.provinceDescription
                    //};
                    return provinceModel;
                }
                else if (t == "District")
                {
                    District district = (District)districtDB.select(id);
                    DistrictModel districtModel = mapper.Map<DistrictModel>(district);
                    return districtModel;
                }
                else if (t == "Ward")
                {
                    Ward ward = (Ward)wardDB.select(id);
                    WardModel wardModel = mapper.Map<WardModel>(ward);
                    return wardModel;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //CREATE

        public string create(UserModel userModel)
        {
            try
            {
                User user = mapper.Map<User>(userModel);
                try
                {
                    userDB.create(user);
                    return "Created";
                }
                catch (Exception ex)
                {
                    return "Connot_Be_Created";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GenerateMD5(string password)
        {
            throw new NotImplementedException();
        }

        public string create(ProvinceModel provinceModel)
        {
            try
            {
                Province province = mapper.Map<Province>(provinceModel);
                try
                {
                    provinceDB.create(province);
                    return "Created";
                }
                catch (Exception ex)
                {
                    return "Connot_Be_Created";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string create(int provinceID, DistrictModel districtModel)
        {
            try
            {
                DistrictModel districtModel2 = districtModel;
                districtModel2.provinceID = provinceID;
                District district = mapper.Map<District>(districtModel2);
                try
                {
                    districtDB.create(district);
                    return "Created";
                }
                catch (Exception ex)
                {
                    return "Connot_Be_Created";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string create(int districtID, WardModel wardModel)
        {
            try
            {
                WardModel wardModel2 = wardModel;
                wardModel2.districtID = districtID;
                Ward ward = mapper.Map<Ward>(wardModel2);
                try
                {
                    wardDB.create(ward);
                    return "Created";
                }
                catch (Exception ex)
                {
                    return "Cannot_Be_Created";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //UPDATE
        public string update(ProvinceModel provinceModel)
        {
            try
            {
                Province province = mapper.Map<Province>(provinceModel);
                try
                {
                    provinceDB.update(province);
                    return "Updated";
                }
                catch (Exception ex)
                {
                    return "Cannot_Found_Provided_ID";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string update(DistrictModel districtModel)
        {
            try
            {
                District district = mapper.Map<District>(districtModel);
                try
                {
                    districtDB.update(district);
                    return "Updated";
                }
                catch (Exception ex)
                {
                    return "Cannot_Found_Provided_ID";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string update(WardModel wardModel)
        {
            try
            {
                Ward ward = mapper.Map<Ward>(wardModel);
                try
                {
                    wardDB.update(ward);
                    return "Updated";
                }
                catch (Exception ex)
                {
                    return "Cannot_Found_Provided_ID";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DELETE
        public string delete(string t, int id)
        {
            try
            {
                if (t == "Province")
                {
                    var x = provinceDB.select(id);
                    try
                    {
                        provinceDB.delete(x);
                        return "Deleted";
                    }
                    catch (Exception ex)
                    {
                        return "Cannot_Found_Provided_ID";
                    }
                }
                else if (t == "District")
                {
                    var x = districtDB.select(id);
                    try
                    {
                        districtDB.delete(x);
                        return "Deleted";
                    }
                    catch (Exception ex)
                    {
                        return "Cannot_Found_Provided_ID";
                    }
                }
                else if (t == "Ward")
                {
                    var x = wardDB.select(id);
                    try
                    {
                        wardDB.delete(x);
                        return "Deleted";
                    }
                    catch (Exception ex)
                    {
                        return "Cannot_Found_Provided_ID";
                    }
                }
                else return "CannotBeDeleted";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LAY DANH SACH XA CUA HUYEN
        public dynamic getAllDistrictInfor(int districtID)
        {
            try
            {
                dynamic data = new System.Dynamic.ExpandoObject();
                District data1 = (District)districtDB.select(districtID);
                if (data1 != null)
                {
                    //DistrictModel districtModel = new DistrictModel()
                    //{
                    //    districtID = data1.districtID,
                    //    districtName = data1.districtName,
                    //    districtDescription = data1.districtDescripton,
                    //    provinceID = data1.provinceID,
                    //};
                    DistrictModel districtModel = mapper.Map<DistrictModel>(data1);
                    List<Ward> data2 = districtDB.getWardByDistrictID(districtID);
                    List<WardModel> listWards = new List<WardModel>();
                    foreach (Ward ward in data2)
                    {
                        listWards.Add(
                        //new WardModel()
                        //{
                        //    wardID = ward.wardID,
                        //    wardName = ward.wardName,
                        //    wardDescription = ward.wardDescription,
                        //    districtID = ward.districtID,
                        //}
                        mapper.Map<WardModel>(ward)
                        );
                    }
                    data.District = districtModel;
                    data.List_Wards = listWards;
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LAY DANH SACH XA, HUYEN CUA TINH
        public dynamic getAllProvinceInfor(int provinceID)
        {
            try
            {
                dynamic data = new System.Dynamic.ExpandoObject();
                Province data1 = (Province)provinceDB.select(provinceID);
                if (data1 != null)
                {
                    //ProvinceModel provinceModel = new ProvinceModel()
                    //{
                    //    //provinceID = data1.provinceID,
                    //    //provinceName = data1.provinceName,
                    //    //provinceDescription = data1.provinceDescription,

                    //};
                    ProvinceModel provinceModel = mapper.Map<ProvinceModel>(data1);
                    List<dynamic> listDistricts = new List<dynamic>();
                    List<District> data2 = provinceDB.getDistrictByProvinceID(provinceID);
                    foreach (District h in data2)
                    {
                        var district = getAllDistrictInfor(h.DistrictID);
                        listDistricts.Add(district);
                    }
                    data.Province = provinceModel;
                    data.List_Districts = listDistricts;
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public class EF_DBcontext
        {
        }
    }
}


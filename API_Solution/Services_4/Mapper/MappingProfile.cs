using API_6._0_4.DBcontext;
using Services_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Services_4.DTOModels;

namespace Services_4.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Province, ProvinceModel>();
            CreateMap<ProvinceModel, Province>();

            CreateMap<District, DistrictModel>();
            CreateMap<DistrictModel, District>();

            CreateMap<Ward, WardModel>();
            CreateMap<WardModel, Ward>();

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}

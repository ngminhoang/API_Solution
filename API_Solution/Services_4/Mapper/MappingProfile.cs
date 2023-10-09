using API_6._0_4.DBcontext;
using Services_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Services_4.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Province, ProvinceModel>()
            .ForMember(destination => destination.provinceID,
                options => options.MapFrom(source => source.provinceID))
            .ForMember(destination => destination.provinceName,
                options => options.MapFrom(source => source.provinceName))
            .ForMember(destination => destination.provinceDescription,
                options => options.MapFrom(source => source.provinceDescription));
            CreateMap<ProvinceModel, Province>()
            .ForMember(destination => destination.provinceID,
                options => options.MapFrom(source => source.provinceID))
            .ForMember(destination => destination.provinceName,
                options => options.MapFrom(source => source.provinceName))
            .ForMember(destination => destination.provinceDescription,
                options => options.MapFrom(source => source.provinceDescription)); ;

            CreateMap<District, DistrictModel>()
            .ForMember(destination => destination.districtID,
                options => options.MapFrom(source => source.districtID))
            .ForMember(destination => destination.districtName,
                options => options.MapFrom(source => source.districtName))
            .ForMember(destination => destination.districtDescription,
                options => options.MapFrom(source => source.districtDescripton))
            .ForMember(destination => destination.provinceID,
                options => options.MapFrom(source => source.provinceID));
            CreateMap<DistrictModel, District>()
            .ForMember(destination => destination.districtID,
                options => options.MapFrom(source => source.districtID))
            .ForMember(destination => destination.districtName,
                options => options.MapFrom(source => source.districtName))
            .ForMember(destination => destination.districtDescripton,
                options => options.MapFrom(source => source.districtDescription))
            .ForMember(destination => destination.provinceID,
                options => options.MapFrom(source => source.provinceID));

            CreateMap<Ward, WardModel>() 
            .ForMember(destination => destination.wardID,
                options => options.MapFrom(source => source.wardID))
            .ForMember(destination => destination.wardName,
                options => options.MapFrom(source => source.wardName))
            .ForMember(destination => destination.wardDescription,
                options => options.MapFrom(source => source.wardDescription))
            .ForMember(destination => destination.districtID,
                options => options.MapFrom(source => source.districtID));
            CreateMap<WardModel, Ward>()
            .ForMember(destination => destination.wardID,
                options => options.MapFrom(source => source.wardID))
            .ForMember(destination => destination.wardName,
                options => options.MapFrom(source => source.wardName))
            .ForMember(destination => destination.wardDescription,
                options => options.MapFrom(source => source.wardDescription))
            .ForMember(destination => destination.districtID,
                options => options.MapFrom(source => source.districtID));
        }
    }
}

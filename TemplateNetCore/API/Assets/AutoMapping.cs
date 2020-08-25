using Core.DTO.Usuarios;
using Data.Data.APIContext.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Assets
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Get Usuarios
            CreateMap<Usuarios, DtoUser>()
                .ForMember(des => des.Activo, opt => opt.MapFrom(c => Convert.ToBoolean(c.Activo)));
            #endregion
            #region Post Usuarios
            CreateMap<DtoUserCreate, Usuarios>()
                .ForMember(des=> des.Id, opt => opt.Ignore())
                .ForMember(des => des.Activo, opt => opt.MapFrom(c => Convert.ToByte(c.Activo)));
            #endregion
            #region Put Usuarios
            CreateMap<DtoUserUpdate, Usuarios>()
                .ForMember(des => des.Activo, opt => opt.MapFrom(c => Convert.ToByte(c.Activo)));
            #endregion
        }
    }
}

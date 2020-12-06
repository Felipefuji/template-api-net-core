using Core.DTO.User;
using Data.Data.APIContext.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$.Assets
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Get Usuarios
            CreateMap<User, DtoUser>()
                .ForMember(des => des.IsEnable, opt => opt.MapFrom(c => Convert.ToBoolean(c.IsEnable)));
            #endregion
            #region Post Usuarios
            CreateMap<DtoUserCreate, User>()
                .ForMember(des=> des.Id, opt => opt.Ignore())
                .ForMember(des => des.IsEnable, opt => opt.MapFrom(c => Convert.ToByte(c.IsEnable)));
            #endregion
            #region Put Usuarios
            CreateMap<DtoUserUpdate, User>()
                .ForMember(des => des.IsEnable, opt => opt.MapFrom(c => Convert.ToByte(c.IsEnable)));
            #endregion
        }
    }
}

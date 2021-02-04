using Core.DTO.User;
using Data.Data.APIContext.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Data.AuthContext.Models;
using Core.DTO.Client;

namespace $safeprojectname$.Assets
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Users
            CreateMap<User, DtoUser>()
                .ForMember(u => u.Email, opt => opt.MapFrom(ur => ur.UserName));
            CreateMap<DtoUser, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
            #endregion
            #region Client
            CreateMap<Client, DtoClient>()
                .ForMember(des => des.IsEnable, opt => opt.MapFrom(c => Convert.ToBoolean(c.IsEnable)));
            CreateMap<DtoClientCreate, Client>()
                .ForMember(des => des.Id, opt => opt.Ignore())
                .ForMember(des => des.IsEnable, opt => opt.MapFrom(c => Convert.ToByte(c.IsEnable)));
            CreateMap<DtoClientUpdate, Client>()
                .ForMember(des => des.IsEnable, opt => opt.MapFrom(c => Convert.ToByte(c.IsEnable)));
            #endregion
        }
    }
}

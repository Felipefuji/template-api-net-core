using Core.DTO.Helpers;
using Core.DTO.Usuarios;
using Core.Helpers;
using Core.Interfaces.Services;
using Data.Data.APIContext.Context;
using Data.Data.APIContext.Models;
using Data.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region Constructor

        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IUsuariosRepository _userRepository;

        public UsuarioService(APIContext context, IMapper mapper, IUsuariosRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        #endregion
        #region Actions

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public async Task<DtoUser> GetUserId(int id)
        {
            DtoUser User = await _userRepository.GetUsers().AsNoTracking().Where(c => c.Id == id).ProjectTo<DtoUser>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return User;
        }

        /// <summary>
        /// Get All Users 
        /// </summary>
        /// <returns></returns>
        public async Task<PagedList<DtoUser>> GetAllUsers(DtoFilterPagedList pagedListParams)
        {
            //Servicio con paginacion en servidor

            PagedList<DtoUser> listResult = null;

            var query = _userRepository.GetUsers().AsNoTracking().IgnoreQueryFilters().ProjectTo<DtoUser>(_mapper.ConfigurationProvider);

            if (pagedListParams.Active)
            {
                listResult = await PagedList<DtoUser>.ToPagedListAsync(query, pagedListParams.PageNumber, pagedListParams.PageSize);
                return listResult;
            }

            listResult = await PagedList<DtoUser>.ToOnlyListAsync(query);

            return listResult;
        }


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<int?> CreateUser(DtoUserCreate data)
        {
            int? result = null;

            Usuarios entity = _mapper.Map<Usuarios>(data);
            _userRepository.AddUser(entity);
            await _context.SaveChangesAsync();

            result = entity.Id;


            return result;
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<int?> UpdateUser(DtoUserUpdate data)
        {
            int? result = null;


            var lastEntity = await _userRepository.GetUsers().IgnoreQueryFilters().Where(c => c.Id == data.Id).FirstOrDefaultAsync();

            if (lastEntity != null)
            {
                Usuarios entity = _mapper.Map(data, lastEntity);
                _userRepository.UpdateUser(entity);
                await _context.SaveChangesAsync();

                result = entity.Id;
            }

            return result;
        }

        /// <summary>
        /// Remove User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveUser(int id) 
        {
            var entity = await _userRepository.GetUsers().IgnoreQueryFilters().Where(c => c.Id == id).FirstOrDefaultAsync();

            if (entity != null)
            {
                _userRepository.DeleteUser(entity);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
        #region Private Method

        #endregion
    }
}

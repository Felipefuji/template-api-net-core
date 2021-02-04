using Core.DTO.Helpers;
using Core.DTO.Client;
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
    public class ClientService : IClientService
    {
        #region Constructor

        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientService(APIContext context, IMapper mapper, IClientRepository clientRepository)
        {
            _context = context;
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        #endregion
        #region Actions

        /// <summary>
        /// Get Client by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoClient> GetClientById(int id)
        {
            DtoClient User = await _clientRepository.GetClient().AsNoTracking().Where(c => c.Id == id).ProjectTo<DtoClient>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return User;
        }

        /// <summary>
        /// Get All Client 
        /// </summary>
        /// <returns></returns>
        public async Task<PagedList<DtoClient>> GetAllClients(DtoFilterPagedList pagedListParams)
        {
            //Servicio con paginacion en servidor

            PagedList<DtoClient> listResult = null;

            var query = _clientRepository.GetClient().AsNoTracking().IgnoreQueryFilters().ProjectTo<DtoClient>(_mapper.ConfigurationProvider);

            if (pagedListParams.Active)
            {
                listResult = await PagedList<DtoClient>.ToPagedListAsync(query, pagedListParams.PageNumber, pagedListParams.PageSize);
                return listResult;
            }

            listResult = await PagedList<DtoClient>.ToOnlyListAsync(query);

            return listResult;
        }


        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<int?> CreateClient(DtoClientCreate data)
        {
            int? result = null;

            Client entity = _mapper.Map<Client>(data);
            _clientRepository.AddClient(entity);
            await _context.SaveChangesAsync();

            result = entity.Id;


            return result;
        }

        /// <summary>
        /// Update Client
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<int?> UpdateClient(DtoClientUpdate data)
        {
            int? result = null;


            var lastEntity = await _clientRepository.GetClient().IgnoreQueryFilters().Where(c => c.Id == data.Id).FirstOrDefaultAsync();

            if (lastEntity != null)
            {
                Client entity = _mapper.Map(data, lastEntity);
                _clientRepository.UpdateClient(entity);
                await _context.SaveChangesAsync();

                result = entity.Id;
            }

            return result;
        }

        /// <summary>
        /// Remove Client by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveClient(int id)
        {
            var entity = await _clientRepository.GetClient().IgnoreQueryFilters().Where(c => c.Id == id).FirstOrDefaultAsync();

            if (entity != null)
            {
                _clientRepository.DeleteClient(entity);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
        #region Private Method

        #endregion
    }
}

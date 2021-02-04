using $safeprojectname$.DTO.Helpers;
using $safeprojectname$.DTO.Client;
using $safeprojectname$.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces.Services
{
    public interface IClientService
    {
        /// <summary>
        /// Get Client by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DtoClient> GetClientById(int id);

        /// <summary>
        /// Get All Client 
        /// </summary>
        /// <returns></returns>
        Task<PagedList<DtoClient>> GetAllClients(DtoFilterPagedList pagedListParams);


        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<int?> CreateClient(DtoClientCreate data);

        /// <summary>
        /// Update Client
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<int?> UpdateClient(DtoClientUpdate data);

        /// <summary>
        /// Remove Client by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveClient(int id);
    }
}

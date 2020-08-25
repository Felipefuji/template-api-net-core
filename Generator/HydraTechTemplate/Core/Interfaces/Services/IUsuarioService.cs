using $safeprojectname$.DTO.Helpers;
using $safeprojectname$.DTO.Usuarios;
using $safeprojectname$.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces.Services
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        Task<DtoUser> GetUserId(int id);

        /// <summary>
        /// Get All Users 
        /// </summary>
        /// <returns></returns>
        Task<PagedList<DtoUser>> GetAllUsers(DtoFilterPagedList pagedListParams);


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<int?> CreateUser(DtoUserCreate data);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<int?> UpdateUser(DtoUserUpdate data);

        /// <summary>
        /// Remove User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveUser(int id);
    }
}

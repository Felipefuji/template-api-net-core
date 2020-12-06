using Data.Data.APIContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interfaces.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get Entities from Users
        /// </summary>
        /// <returns></returns>
        IQueryable<User> GetUsers();

        /// <summary>
        /// Add new Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        void AddUser(User entity);

        /// <summary>
        /// Update Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        void UpdateUser(User entity);

        /// <summary>
        /// Delete Entity Usuarios
        /// </summary>
        /// <param name="entity"></param>
        void DeleteUser(User entity);
    }
}

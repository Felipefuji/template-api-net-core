using $safeprojectname$.$safeprojectname$.APIContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace $safeprojectname$.Interfaces.Repositories
{
    public interface IUsuariosRepository
    {
        /// <summary>
        /// Get Entities from Users
        /// </summary>
        /// <returns></returns>
        IQueryable<Usuarios> GetUsers();

        /// <summary>
        /// Add new Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        void AddUser(Usuarios entity);

        /// <summary>
        /// Update Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        void UpdateUser(Usuarios entity);

        /// <summary>
        /// Delete Entity Usuarios
        /// </summary>
        /// <param name="entity"></param>
        void DeleteUser(Usuarios entity);
    }
}

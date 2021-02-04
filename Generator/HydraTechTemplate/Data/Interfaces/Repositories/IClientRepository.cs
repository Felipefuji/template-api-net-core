using $safeprojectname$.$safeprojectname$.APIContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace $safeprojectname$.Interfaces.Repositories
{
    public interface IClientRepository
    {
        /// <summary>
        /// Get Entities from Client
        /// </summary>
        /// <returns></returns>
        IQueryable<Client> GetClient();

        /// <summary>
        /// Add new Entity Client
        /// </summary>
        /// <param name="entity"></param>
        void AddClient(Client entity);

        /// <summary>
        /// Update Entity Client
        /// </summary>
        /// <param name="entity"></param>
        void UpdateClient(Client entity);

        /// <summary>
        /// Delete Entity Client
        /// </summary>
        /// <param name="entity"></param>
        void DeleteClient(Client entity);
    }
}

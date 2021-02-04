using Data.Data.APIContext.Context;
using Data.Data.APIContext.Models;
using Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        #region Constructor
        private readonly APIContext _context;
        public ClientRepository(APIContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Get Entities from Client
        /// </summary>
        /// <returns></returns>
        public IQueryable<Client> GetClient()
        {
            return _context.Clients;
        }

        /// <summary>
        /// Add new Entity Client
        /// </summary>
        /// <param name="entity"></param>
        public void AddClient(Client entity)
        {
            _context.Clients.Add(entity);
        }

        /// <summary>
        /// Update Entity Client
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateClient(Client entity)
        {
            _context.Clients.Update(entity);
        }

        /// <summary>
        /// Delete Entity Client
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteClient(Client entity)
        {
            _context.Clients.Remove(entity);
        }
    }
}

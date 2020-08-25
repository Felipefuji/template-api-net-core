using Data.Data.APIContext.Context;
using Data.Data.APIContext.Models;
using Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Data.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        #region Constructor
        private readonly APIContext _context;
        public UsuariosRepository(APIContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Get Entities from Users
        /// </summary>
        /// <returns></returns>
        public IQueryable<Usuarios> GetUsers()
        {
            return _context.Usuarios;
        }

        /// <summary>
        /// Add new Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        public void AddUser(Usuarios entity)
        {
            _context.Usuarios.Add(entity);
        }

        /// <summary>
        /// Update Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateUser(Usuarios entity)
        {
            _context.Usuarios.Update(entity);
        }

        /// <summary>
        /// Delete Entity Usuarios
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteUser(Usuarios entity)
        {
            _context.Usuarios.Remove(entity);
        }
    }
}

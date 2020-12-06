using $safeprojectname$.$safeprojectname$.APIContext.Context;
using $safeprojectname$.$safeprojectname$.APIContext.Models;
using $safeprojectname$.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.$safeprojectname$.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Constructor
        private readonly APIContext _context;
        public UserRepository(APIContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Get Entities from Users
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> GetUsers()
        {
            return _context.Users;
        }

        /// <summary>
        /// Add new Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        public void AddUser(User entity)
        {
            _context.Users.Add(entity);
        }

        /// <summary>
        /// Update Entity Usuario
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateUser(User entity)
        {
            _context.Users.Update(entity);
        }

        /// <summary>
        /// Delete Entity Usuarios
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteUser(User entity)
        {
            _context.Users.Remove(entity);
        }
    }
}

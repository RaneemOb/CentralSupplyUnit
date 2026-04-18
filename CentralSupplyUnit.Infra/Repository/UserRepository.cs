using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Interfaces.Repository;
using CentralSupplyUnit.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Infra.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetByCredentials(string username, string password)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}

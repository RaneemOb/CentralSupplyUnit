using CentralSupplyUnit.Core.Interfaces.Repository;
using CentralSupplyUnit.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Service
{
    public class AuthService :IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly ITokenGenerator _token;

        public AuthService(IUserRepository repo, ITokenGenerator token)
        {
            _repo = repo;
            _token = token;
        }

        public string Login(string username, string password)
        {
            var user = _repo.GetByCredentials(username, password);

            if (user == null)
                return null;

            return _token.Generate(user);
        }
    }
}

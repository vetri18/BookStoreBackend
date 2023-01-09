using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        public RegistrationModel AddUser(RegistrationModel usermodel);

        public string UserLogin(LoginModel login);
    }
}

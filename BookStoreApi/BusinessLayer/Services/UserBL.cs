﻿using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public RegistrationModel AddUser(RegistrationModel usermodel)
        {
            try
            {
                return this.userRL.AddUser(usermodel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

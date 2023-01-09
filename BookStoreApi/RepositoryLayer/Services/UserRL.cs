using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        SqlConnection sqlConnection;
        private readonly IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public RegistrationModel AddUser(RegistrationModel usermodel)
        {
            this.sqlConnection = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            using (sqlConnection)
                try
                {

                    SqlCommand command = new SqlCommand("spAddUser", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    command.Parameters.AddWithValue("@fullname", usermodel.FullName);
                    command.Parameters.AddWithValue("@email", usermodel.Email);
                    command.Parameters.AddWithValue("@password", usermodel.Password);
                    command.Parameters.AddWithValue("@mobilenumber", usermodel.Mobile_Number);
                    var result = command.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return usermodel;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    this.sqlConnection.Close();
                }

        }
    }
}

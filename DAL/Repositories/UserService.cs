using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;
        public UserService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        private User Converter(IDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                NickName = (string)reader["NickName"],
                Email = (string)reader["Email"],
                IsAdmin = (bool)reader["IsAdmin"]
            };
        }

        public bool RegisterUser(string nickname, string email, string password)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "RegisterUser";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("nickname", nickname);
                    cmd.Parameters.AddWithValue("pwd", password);
                    cmd.Parameters.AddWithValue("email", email);

                    cnx.Open();
                    return cmd.ExecuteNonQuery() == 1;
                    cnx.Close();
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users";

                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Converter(reader);
                        }
                    }
                }
            }
        }

        public User Login(string email, string password)
        {
       
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "Login";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("pwd", password);
                    cmd.Parameters.AddWithValue("email", email);

                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           return Converter(reader);
                        }
                    }
                }
            }
         throw new Exception();
        }
    }
}

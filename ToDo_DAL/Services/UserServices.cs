﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_DAL.Models;
using ToDo_DAL.Repositories;
using ToDo_DAL.Utils;

namespace ToDo_DAL.Services
{
    public class UserServices : IRepository<User>
    {
        private static UserServices _instance;

        public static UserServices Instance
        {
            get
            {
                _instance = _instance ?? new UserServices();
                return _instance;
            }
        }

        public void Create(User t)
        {
            /*
            using (SqlCommand command = Handler.ConnecDB.CreateCommand())
            {
                command.CommandText = "insert into [User] (firstname,lastname,email,[password]) output inserted.id " +
                    "values (@first,@last,@mail,@pw)";

                command.Parameters.AddWithValue("first", t.Firstname);
                command.Parameters.AddWithValue("last", t.Lastname);
                command.Parameters.AddWithValue("mail", t.Email);
                command.Parameters.AddWithValue("pw", t.Password);

                Handler.ConnecDB.Open();
                t.Id = (int)command.ExecuteScalar();
                Handler.ConnecDB.Close();
            }*/

            using (SqlCommand cmd = new SqlCommand("RegisterUser", Handler.ConnecDB))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("LastName", t.Lastname);
                cmd.Parameters.AddWithValue("FirstName", t.Firstname);
                cmd.Parameters.AddWithValue("Email", t.Email);
                cmd.Parameters.AddWithValue("Passwd", t.Password);

                Handler.ConnecDB.Open();
                cmd.ExecuteNonQuery();
                Handler.ConnecDB.Close();

            }
        }

        public User GetOne(User user)
        {

            using (SqlCommand cmd = new SqlCommand("LoginUser", Handler.ConnecDB))
            {

                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("Email", user.Email);
                cmd.Parameters.AddWithValue("Passwd", user.Password);

                Handler.ConnecDB.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    User u = new User();

                    if (dr.Read())
                    {
                        u.Id = (int)dr["id"];
                        u.Firstname = dr["firstname"].ToString();
                        u.Lastname = dr["lastname"].ToString();
                        u.Email = dr["email"].ToString();                     
                    }

                    Handler.ConnecDB.Close();
                    return u;
                }

            }
            /*Handler.ConnecDB.Open();

            //creation de la cmd
            using (SqlCommand cmd = Handler.ConnecDB.CreateCommand())
            {

                cmd.CommandText = "SELECT * FROM [User] WHERE email=@mail and [password] = @pw";

                cmd.Parameters.AddWithValue("mail", user.Email);
                cmd.Parameters.AddWithValue("pw", user.Password);

                //execution
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    User u = new User();
                 
                    if (dr.Read())
                    {
                        u.Id = (int)dr["id"];
                        u.Firstname = dr["firstname"].ToString();
                        u.Lastname = dr["lastname"].ToString();
                        u.Email = dr["email"].ToString();
                        u.Password = dr["password"].ToString();
                    }

                    Handler.ConnecDB.Close();
                    return u;
                }

            }*/
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetOne(int id)
        {
            throw new NotImplementedException();
        }

       
        public void Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}

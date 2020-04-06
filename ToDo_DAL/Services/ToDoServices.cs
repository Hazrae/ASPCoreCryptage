using System;
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
    public class ToDoServices : IRepository<ToDo>
    {

        // Singleton instance ToDoService
        private static ToDoServices _instance;

        public static ToDoServices Instance
        {
            get 
            { 
                _instance = _instance ?? new ToDoServices();
                return _instance;  
            }

        }
        private ToDoServices()
        {

        }
                
        public void Create(ToDo t)
        {
            using (SqlCommand command = Handler.ConnecDB.CreateCommand())
            {
                command.CommandText = "insert into [ToDo] (title,descr,state,userId) " +
                    "values (@t,@d,@s,@u)";

                command.Parameters.AddWithValue("t", t.Title);
                command.Parameters.AddWithValue("d", t.Descr);
                command.Parameters.AddWithValue("s", t.State);
                command.Parameters.AddWithValue("u", t.UserId);

                Handler.ConnecDB.Open();
                command.ExecuteScalar();
                Handler.ConnecDB.Close();
            }

        }

        public void Delete(int id)
        {
            Handler.ConnecDB.Open();
            using (SqlCommand cmd = Handler.ConnecDB.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM ToDo WHERE id = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                Handler.ConnecDB.Close();

            }             
            
        }

        public List<ToDo> GetAll()
        {
            List<ToDo> list = new List<ToDo>();
            Handler.ConnecDB.Open();

            //creation de la cmd
            using (SqlCommand cmd = Handler.ConnecDB.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM ToDo";

                //execution
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    //creation de la liste en bouclant sur le DR
                    while (dr.Read())
                    {                   

                        list.Add(new ToDo
                        {
                            Id = (int)dr["id"],
                            Title = dr["title"].ToString(),
                            Descr = dr["descr"].ToString(),
                            State = (bool)dr["state"],                         
                        

                        }); ; 
                    }
                }
            }
            Handler.ConnecDB.Close();
            return list;

        }

        public List<ToDo> GetByUser(int id)
        {
            List<ToDo> list = new List<ToDo>();
            Handler.ConnecDB.Open();

            //creation de la cmd
            using (SqlCommand cmd = Handler.ConnecDB.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM ToDo WHERE userId=@id";


                cmd.Parameters.AddWithValue("id", id);

                //execution
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    //creation de la liste en bouclant sur le DR
                    while (dr.Read())
                    {

                        list.Add(new ToDo
                        {
                            Id = (int)dr["id"],
                            Title = dr["title"].ToString(),
                            Descr = dr["descr"].ToString(),
                            State = (bool)dr["state"]                           

                        }); ;
                    }
                }
            }
            Handler.ConnecDB.Close();
            return list;

        }

        public ToDo GetOne(int id)
        {
            Handler.ConnecDB.Open();
            ToDo todo = new ToDo();

            //creation de la cmd
            using (SqlCommand cmd = Handler.ConnecDB.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM ToDo WHERE id = @id";
                cmd.Parameters.AddWithValue("id", id);

                //exécution et boucle sur le DR pour garnir l'objet
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    todo.Id = (int)dr["id"];
                    todo.Title = dr["title"].ToString();
                    todo.Descr = dr["descr"].ToString();
                    todo.State = (bool)dr["state"];
                }
            }
            Handler.ConnecDB.Close();
            return todo;
        }

        
        public void Update(ToDo t)
        {
             throw new NotImplementedException();
        }
        
    }
}

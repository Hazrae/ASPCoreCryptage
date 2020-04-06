using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_DAL.Utils
{
    public static class Handler
    {
        private const string stringConnec = @"Data Source=KEVIN-PC\SQLSERVER;Initial Catalog=ToDoSession;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static SqlConnection _connecDB;

        public static SqlConnection ConnecDB
        {
            get 
            { 
                _connecDB = _connecDB ?? new SqlConnection(stringConnec);
                return _connecDB;   
            }

        }

    }
}

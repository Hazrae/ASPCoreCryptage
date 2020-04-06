using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDo_DAL.Models;
using ToDo_DAL.Services;

namespace ToDo_API.Controllers
{
    public class UserController : ApiController
    {
        private static UserController _instance;

        public static UserController Instance
        {
            get
            {
                _instance = _instance ?? new UserController();
                return _instance;
            }
        }
                  
        [Route("api/User/{id:int}")]
        public User GetOne(int id)
        {
            return UserServices.Instance.GetOne(id);
        }

        [HttpPost]
        [Route("api/UserLogin/")]
        public User GetLogin(User u)
        {
            return UserServices.Instance.GetOne(u);
        }


        [HttpPost]
        [Route("api/User/")]
        public User Post(User u)
        {
            UserServices.Instance.Create(u);
            return u;
        }

       
    }
}

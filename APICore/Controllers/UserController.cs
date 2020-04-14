using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo_DAL.Models;
using ToDo_DAL.Services;
using ToolBox.Cryptography;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRSAEncryption _encrypt;
        public UserController(IRSAEncryption encrypt)
        {
            _encrypt = encrypt;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User u)
        {
            string pwDecrypt = _encrypt.Decrypt(Convert.FromBase64String(u.Password));
            u.Password = pwDecrypt; 
            UserServices.Instance.Create(u);        
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

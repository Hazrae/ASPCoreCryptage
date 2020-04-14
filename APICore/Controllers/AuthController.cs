using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolBox.Cryptography;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRSAEncryption _encrypt;
        public AuthController(IRSAEncryption encrypt)
        {
            _encrypt = encrypt;
        }

        public byte[] GetKey()
        {
            
            return _encrypt.PublicBinaryKey;
        }
    }
}
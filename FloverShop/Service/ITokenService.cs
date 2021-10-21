using FloverShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloverShop.Service
{
    public interface ITokenService
    {
        public string CreateToken(UserDTO userDTO);
    }
}

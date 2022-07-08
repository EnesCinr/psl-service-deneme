using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Entities.Dtos.Auth
{
    public class LoginDto
    {
        public string IdentifierInfo { get; set; }
        public string Password { get; set; }
    }
}

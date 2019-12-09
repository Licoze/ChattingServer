using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattingServer.ControllerModels
{
    public class UserLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

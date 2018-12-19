using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDiary.Interfaces
{
    public interface IAuthenticationService
    {
        void Login(string login, string password);
        void LogOut();
    }
}

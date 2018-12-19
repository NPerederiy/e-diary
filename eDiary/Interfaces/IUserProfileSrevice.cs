using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDiary.Interfaces
{
    public interface IUserProfileSrevice
    {
        void AddUserProfile(string login, string password, string name, string email);
        object GetUserProfile(int id);
        void UpdateUserProfile(int id);
        void DeleteUserProfile(int id);
    }
}

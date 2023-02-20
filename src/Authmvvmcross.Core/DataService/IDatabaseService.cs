using System;
using System.Collections.Generic;
using System.Text;
using AuthenticationApp.Model;

namespace Authmvvmcross.Core.DataService
{
    public interface IDatabaseService
    {
        void Insert(User user);
        void Update(User user);
        void Delete(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
    }
}

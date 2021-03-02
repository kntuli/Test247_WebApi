using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test247_WebApi.Models;

namespace Test247_WebApi.DataProvider
{
    public interface IUserDataProvider
    {
        Task AddUser(UserModel item);
        Task<IEnumerable<UserModel>> GetUser(string userName, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Data.Models;

namespace TicTacToe.Repository.UserRepository
{
    public interface IUserRepository
    {
        List<Users> GetUserList();
        Users GetUserById(Users input);
        int Insert(Users input);
        Users Update(Users input);
        bool Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Data.Models;

namespace TicTacToe.Service.UserService
{
    public interface IUserService
    {
        List<Users> GetUserList();
        Users GetUserById(Users input);
        Users GetUserByNicknameAndPassword(Users input);
        Users Insert(Users input);
        Users Update(Users input);
        bool Delete(int id);
    }
}
